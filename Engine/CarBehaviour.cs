using System;
using CarPhysicsEngine.Acceleration;
using CarPhysicsEngine.Turning;

namespace CarPhysicsEngine
{
    public class CarBehaviour
    {
        private double throttleInput;

        public double ThrottleInput
        {
            get { return throttleInput; }
            set
            {
                if (value >= 0 && value <= 100)
                    throttleInput = value;
            }
        }

        /// <summary>
        ///     Real-world position of car's centre
        /// </summary>
        public double XCoordinate { get; private set; }

        /// <summary>
        ///     Real-world position of car's centre
        /// </summary>
        public double YCoordinate { get; private set; }

        // Use to calculate DeltaT
        private DateTime previousDateTime;
        private DateTime currentDateTime;

        /// <summary>
        ///     Change in time between frames [seconds]
        /// </summary>
        public double DeltaT
        {
            get
            {
                //return 0.01;
                var difference = (currentDateTime - previousDateTime);
                return difference.TotalSeconds;
            }
        }

        /// <summary>
        ///     Current Forward Velocity [m/s]
        /// </summary>
        public double ForwardVelocity { get; private set; }

        /// <summary>
        ///     Stores the yaw velocity of the previous iteration
        /// </summary>
        private double previousYawVelocity;

        public double YawAngle { get; set; }

        // steering angle in radians => input
        private double steerAngle;

        /// <summary>
        ///     Input wheel angle  [radians]
        /// </summary>
        public double SteerAngle 
        {
            get { return steerAngle; }
            set
            {
                // the max angle of the wheel is +-28 degrees
                const double angleRadiansLimit = 28 * Math.PI / 180;

                if (value <= angleRadiansLimit && value >= -angleRadiansLimit)
                    steerAngle = value;
            }
        }

        public readonly Tyre Tyre;
        public readonly Forces Forces;
        public readonly Movement Movement;
        public readonly Position Position;
        public readonly Acceleration.Acceleration Acceleration;

        public CarBehaviour()
        {
            previousYawVelocity = 0;
            ForwardVelocity = 0;
            ThrottleInput = 0;

            YawAngle = 0;
            SteerAngle = 0;

            currentDateTime = previousDateTime = DateTime.Now;

            XCoordinate = YCoordinate = 0;

            Tyre = new Tyre();
            Forces = new Forces();
            Movement = new Movement();
            Position = new Position();
            Acceleration = new Acceleration.Acceleration();
            
        }

        public void  Run()
        {
            // Acceleration is run before Turning because we need forward velocity
            CalculateAcceleration();

            if (ForwardVelocity != 0)
            {
                CalculateTurning();
            }

            previousDateTime = currentDateTime;
            currentDateTime = DateTime.Now;
        }

        private void CalculateAcceleration()
        {
            Acceleration.ThrottleInput = ThrottleInput;
            Acceleration.ForwardVelocityInput = ForwardVelocity;
            Acceleration.DeltaT = DeltaT;
            Acceleration.Run();
            ForwardVelocity = Acceleration.ForwardVelocityOutput;
        }

        private void CalculateTurning()
        {
            // Initialize the properties in Tyre
            Tyre.ForwardVelocity = ForwardVelocity;
            Tyre.SteerAngle = SteerAngle;
            Tyre.LateralVelocity = Movement.LateralVelocity();
            Tyre.YawVelocity = Movement.YawVelocity();

            // Initialize the properties in Forces
            Forces.TyreForceFront = Tyre.TyreForceFront();
            Forces.TyreForceRear = Tyre.TyreForceRear();

            // Initialize the properties in Movement
            Movement.FyTotal = Forces.FyTotal();
            Movement.MzTotal = Forces.MzMoment();
            Movement.DeltaT = DeltaT;
            Movement.ForwardVelocity = ForwardVelocity;

            // Initialize the properties in Position
            previousYawVelocity = Position.YawVelocity = Movement.YawVelocity();
            Position.LateralVelocity = Movement.LateralVelocity();
            Position.DeltaT = DeltaT;
            Position.ForwardVelocity = ForwardVelocity;
            Position.YawAngle = YawAngle;

            Position.YawVelocityIntegral();
            // Calculate the new world coordinates for the vehicle
            XCoordinate += Position.VehicleDisplacementX();
            YCoordinate += Position.VehicleDisplacementY();

            //Set previous movement values
            Movement.PreviousLateralVelocity = Movement.LateralVelocity();
            Movement.PreviousYawVelocity = previousYawVelocity;

            YawAngle += DeltaT * Movement.YawVelocity();
        }
    }
}