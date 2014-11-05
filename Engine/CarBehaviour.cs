using System;

namespace CarPhysicsEngine
{
    public class CarBehaviour
    {
        /// <summary>
        ///     Acceleration due to gravity
        /// </summary>
        private static double gravity;

        public readonly Forces forces;
        public Position position;
        /// <summary>
        ///     Forward Velocity for current iteration
        /// </summary>
        public readonly double forwardVelocity;

        /// <summary>
        ///     Lateral velocity for current iteration
        /// </summary>
        private readonly double lateralVelocity;

        public readonly Movement movement;
        public readonly Tyre tyre;

        /// <summary>
        ///     Time step for current interation (for use with integration)
        /// </summary>
        private DateTime currentTime;

        /// <summary>
        ///     Forward velocity for previous iteration
        /// </summary>
        private double previousForwardVelocity;

        /// <summary>
        ///     Tyre force for previous iteration
        /// </summary>
        private double previousFyTotal;

        /// <summary>
        ///     Lateral velocity for previous iteration
        /// </summary>
        private double previousLateralVelocity;

        /// <summary>
        ///     Torque (moment) for previous iteration
        /// </summary>
        private double previousMzTotal;

        /// <summary>
        ///     Time step for previous iteration (for use with integration)
        /// </summary>
        private DateTime previousTime;

        /// <summary>
        ///     Yaw velocity for previous iteration
        /// </summary>
        private double previousYawVelocity;

        /// <summary>
        ///     Steer angle in radians. Input from steering wheel
        ///     Should not be greater than 30 degrees = Pi/6
        /// </summary>
        private double steerAngleRadians;
        public double SteerAngleRadians { 
            get { return steerAngleRadians; }
            
            set
            {
                if (value <= Math.PI/6 && value >= -(Math.PI/6))
                    steerAngleRadians = value;
            }
        }

        /// <summary>
        ///     Current X-coordinate of vehicle
        /// </summary>
        public double xCoordinate { get; private set; }

        /// <summary>
        ///     Current Y-coordinate of vehicle
        /// </summary>
        public double yCoordinate { get; private set; }

        public CarBehaviour()
        {
            SteerAngleRadians = 0;

            // Mass of the car
            const int mass = 1150;

            // Gravity (constant)
            gravity = 9.81f;

            // Wheelbase (distance between the centres of front and real wheels)
            const float length = 2.66f;

            // Length from front wheel to centre of gravity
            const float a = 1.06f;

            // Length from rear wheel to centre of gravity
            const float b = length - a;

            // Moment of intertia
            const int I = 1850;

            // Nominal load
            const double fz0 = 8000;

            // Forward velocity in m/s for 80km/h
            forwardVelocity = 80/3.6;

            // !TODO: Why is previous forward velocity initialized to the current forward velocity?
            previousForwardVelocity = forwardVelocity;

            currentTime = DateTime.Now;

            // Initialized to a small number greater than zero for first iteration
            var yawVelocityRadians = 0;

            // Initialized to zero because values are unknown at first iteration
            previousFyTotal = previousMzTotal = previousYawVelocity = lateralVelocity = previousLateralVelocity = 0;

            // Object creation initialization
            tyre = new Tyre(mass, gravity, length, SteerAngleRadians, yawVelocityRadians, lateralVelocity, a, b, fz0, forwardVelocity);
            forces = new Forces(tyre.tyreForceFront(), tyre.tyreForceRear(), a, b);
            movement = new Movement(forces.FyTotal(), forces.MzMoment(), I, mass, previousFyTotal, previousMzTotal, dt,
                forwardVelocity);

            xCoordinate = yCoordinate = 0;
        }

        /// <summary>
        ///     Calculate time step in seconds
        ///     (currentTime - previousTime) in seconds
        ///     !TODO: Time should be provided externally because we shouldn't take into account time taken for execution of this
        ///     class
        /// </summary>
        private double dt
        {
            get { return 0.01; }
        }

        /// <summary>
        ///     This method is executed when the frame is updated
        /// </summary>
        public void Run()
        {
            // Check if this is the first iteration.
            // If yes, initialize both previous and current time to DateTime.Now
            // If no, update the value of previous time to current time.
            if (forwardVelocity == 0)
            {
                previousTime = currentTime = DateTime.Now;
            }
            else
            {
                previousTime = currentTime;
                currentTime = previousTime.AddSeconds(dt);
            }

            // Update time in movement to ensure it always has the latest values
            movement.dt = dt;

            tyre.SteerAngle = SteerAngleRadians;
            tyre.YawVelocity = movement.yawVelocity();
            tyre.LateralVelocity = movement.lateralVelocity();

            forces.TyreForceFront = tyre.tyreForceFront();
            forces.TyreForceRear = tyre.tyreForceRear();

            movement.CurrentFyTotal = forces.FyTotal();
            movement.CurrentMzTotal = forces.MzMoment();

            // Save the current values for future iterations (needed for integration)
            previousFyTotal = movement.CurrentFyTotal;
            previousMzTotal = movement.CurrentMzTotal;

            // Initialized here because we need output 
            position = new Position(forwardVelocity, previousForwardVelocity, yawVelocity(), 
                previousYawVelocity, lateralVelocity, previousLateralVelocity, dt);

            //Save the current values for future iterations (needed for integration)
            previousForwardVelocity = position.CurrentForwardVelocity;
            previousLateralVelocity = position.CurrentLateralVelocity;
            previousYawVelocity = position.CurrentYawVelocity;

            // Update X and Y coordinates based on calculated displacement
            double vehicleDisplacementX = position.displacementX();
            double vehicleDisplacementY = position.displacementY();
            xCoordinate += Math.Cos(steerAngleDegrees()) * vehicleDisplacementX + Math.Sin(steerAngleDegrees())*vehicleDisplacementY;
            yCoordinate += Math.Sin(steerAngleDegrees())*vehicleDisplacementX - Math.Cos(steerAngleDegrees())*vehicleDisplacementY;

            // ---
            // Output for testing purposes
            Console.WriteLine("X: " + xCoordinate);
            Console.WriteLine("Y: " + yCoordinate);
            
            Console.WriteLine();
        }

        /// <summary>
        ///     Calculate the acceleration for the car
        /// </summary>
        /// <returns>Acceleration</returns>
        public double acceleration()
        {
            var n1 = movement.accelerationY() + (movement.yawVelocity()*forwardVelocity);

            return n1/gravity;
        }

        /// <summary>
        ///     Calculate the yaw velocity
        /// </summary>
        /// <returns>Yaw Velocity</returns>
        public double yawVelocity()
        {
            return movement.yawVelocity()*(180/Math.PI);
        }

        /// <summary>
        ///     Calculate the steer angle in degrees
        /// </summary>
        /// <returns>Steer angle in degrees</returns>
        public double steerAngleDegrees()
        {
            var n1 = Math.Atan(movement.lateralVelocity()/forwardVelocity);
            return n1*(180/Math.PI);
        }
    }
}