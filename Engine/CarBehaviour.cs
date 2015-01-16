using System;
using CarPhysicsEngine.Turning;

namespace CarPhysicsEngine
{
    public class CarBehaviour
    {
        // Pre-defined variables from voertuigdata.m
        public readonly double ForwardVelocity; // [m/s]
        private double steerAngle; // steering angle in radians => input

        /// <summary>
        /// Stores the yaw velocity of the previous iteration
        /// </summary>
        private double previousYawVelocity;

        public double YawAngle { get; set; }

        /// <summary>
        /// Input wheel angle in Radians
        /// </summary>
        public double SteerAngle {
            get { return steerAngle; }
            set
            {
                // the max angle of the wheel is +-28 degrees
                const double angleRadiansLimit = 28 * Math.PI / 180;

                if (value <= angleRadiansLimit && value >= -angleRadiansLimit)
                    steerAngle = value;
            }
        }

        /// <summary>
        /// Real-world position of car's centre
        /// </summary>
        public double XCoordinate { get; private set; }

        /// <summary>
        /// Real-world position of car's centre
        /// </summary>
        public double YCoordinate { get; private set; }

        public readonly Tyre Tyre;
        public readonly Forces Forces;
        public readonly Movement Movement;
        public readonly Position Position;

        public CarBehaviour()
        {
            ForwardVelocity = 80 / 3.6; // 80 km/h => m/s
            previousYawVelocity = 0; // Initialized to zero because execution hasn't run.

            YawAngle = 0;

            //Steerangle has to be set to 0 for initial straight movement
            SteerAngle = 0.00;
            XCoordinate = YCoordinate = 0;

            Tyre = new Tyre(ForwardVelocity, SteerAngle);
            Forces = new Forces();
            Movement = new Movement(ForwardVelocity);
            Position = new Position(ForwardVelocity, YawAngle);
        }

        public void  Run()
        {
            // Initialize the properties in Tyre
            Tyre.SteerAngle = SteerAngle;
            Tyre.LateralVelocity = Movement.LateralVelocity();
            Tyre.YawVelocity = Movement.YawVelocity();

            // Initialize the properties in Forces
            Forces.TyreForceFront = Tyre.TyreForceFront();
            Forces.TyreForceRear = Tyre.TyreForceRear();

            // Initialize the properties in Movement
            Movement.FyTotal = Forces.FyTotal();
            Movement.MzTotal = Forces.MzMoment();
            
            // Initialize the properties in Position
            previousYawVelocity = Position.YawVelocity = Movement.YawVelocity();
            Position.LateralVelocity = Movement.LateralVelocity();

            Position.YawVelocityIntegral();
            // Calculate the new world coordinates for the vehicle
            XCoordinate += Position.VehicleDisplacementX();
            YCoordinate += Position.VehicleDisplacementY();
            
            //Set previous movement values
            Movement.PreviousLateralVelocity = Movement.LateralVelocity();
            Movement.PreviousYawVelocity = previousYawVelocity;

            YawAngle += Setup.DeltaT * Movement.YawVelocity();
        }
    }
}