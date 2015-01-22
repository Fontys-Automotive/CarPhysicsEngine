using System;
using CarPhysicsEngine.Turning;

namespace CarPhysicsEngine
{
    public class CarBehaviour
    {
        /// <summary>
        ///     Percentage input from throttle pedal (0 - 100)
        /// </summary>
        public double ThrottleInput
        {
            get { return throttleInput; }
            set { throttleInput = Helpers.SaturationDynamic(0, 100, value); }
        }
        private double throttleInput;

        /// <summary>
        ///     Percentage input from brake pedal (0 - 100)
        /// </summary>
        public double BrakeInput
        {
            get { return brakeInput; }
            set { brakeInput = Helpers.SaturationDynamic(0, 100, value); }
        }
        private double brakeInput;

        /// <summary>
        ///     Input from steering wheel  [angle-radians]
        /// </summary>
        public double SteerAngle
        {
            get { return steerAngle; }
            set
            {
                const double angleRadiansLimit = 0.733038285837618D; // (720/17) * (π/180)

                steerAngle = Helpers.SaturationDynamic(- angleRadiansLimit, angleRadiansLimit, value);
            }
        }
        private double steerAngle;

        /// <summary>
        ///     Real-world position of car's centre
        /// </summary>
        public double XCoordinate { get; private set; }

        /// <summary>
        ///     Real-world position of car's centre
        /// </summary>
        public double YCoordinate { get; private set; }

        /// <summary>
        ///     Change in time between frames [seconds]
        /// </summary>
        public double DeltaT
        {
            get { return (currentDateTime - previousDateTime).TotalSeconds; }
        }
        private DateTime previousDateTime;
        private DateTime currentDateTime;

        /// <summary>
        ///     Current Forward Velocity [m/s]
        /// </summary>
        public double ForwardVelocity { get; private set; }

        /// <summary>
        ///     Stores the yaw velocity of the previous iteration
        /// </summary>
        private double previousYawVelocity;

        private double YawAngle { get; set; }

        private readonly Tyre tyre;
        public readonly Forces Forces;
        public readonly Movement Movement;
        public readonly Position Position;
        public readonly Acceleration.Acceleration Acceleration;

        public CarBehaviour()
        {
            previousYawVelocity = 0;
            ForwardVelocity = 0;
            ThrottleInput = 0;
            BrakeInput = 0;

            YawAngle = 0;
            SteerAngle = 0;

            currentDateTime = previousDateTime = DateTime.Now;

            XCoordinate = YCoordinate = 0;

            tyre = new Tyre();
            Forces = new Forces();
            Movement = new Movement();
            Position = new Position();
            Acceleration = new Acceleration.Acceleration();
        }

        public void  Run()
        {
            // Acceleration is run before Turning because we need forward velocity
            CalculateAcceleration();

            // Forward Velocity needs to be greater than 0 to compute Alpha Front/Rear
            if (!ForwardVelocity.Equals(0))
            {
                CalculateTurning();
            }

            previousDateTime = currentDateTime;
            currentDateTime = DateTime.Now;
        }

        private void CalculateAcceleration()
        {
            Acceleration.ThrottleInput = ThrottleInput;
            Acceleration.BrakeInput = BrakeInput;
            Acceleration.ForwardVelocityInput = ForwardVelocity;
            Acceleration.DeltaT = DeltaT;

            ForwardVelocity = Acceleration.Run();
        }

        private void CalculateTurning()
        {
            // Initialize the properties in Tyre
            tyre.ForwardVelocity = ForwardVelocity;
            tyre.SteerAngle = SteerAngle;
            tyre.LateralVelocity = Movement.LateralVelocity();
            tyre.YawVelocity = Movement.YawVelocity();

            // Initialize the properties in Forces
            Forces.TyreForceFront = tyre.TyreForceFront();
            Forces.TyreForceRear = tyre.TyreForceRear();

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