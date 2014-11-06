using System;

namespace CarPhysicsEngine
{
    public class CarBehaviour
    {
        // Pre-defined variables from voertuigdata.m
        private readonly double mass;// vehicle mass [kg]
        private readonly double gravity; // acceleration due to gravity [m/s^2]
        private readonly double lengthWheelbase; // wheelbase length [m]
        private readonly double lengthFront; // distance from front axle to centre [m]
        private readonly double lengthRear; // distance from rear axle to centre [m]
        private readonly double inertiaMoment; // moment of inertia of vehicle on z-axis [kgm^2]
        private readonly double ETA; // understeer factor. Plausible max value is 0.04
        private readonly double Fz0; // Nominal load [N]
        private readonly double Fz1; // Axle load front [N]
        private readonly double Fz2; // Axle load read [N]
        private readonly double dFz1;
        private readonly double dFz2;
        private readonly double mu1 = 0.9; // coefficient of friction front [-]
        private readonly double mu2 = 0.9; // coefficient of friction rear [-]
        private readonly double D1; // Peak-factor front [N]
        private readonly double D2; // Peak-factor rear [N]
        private readonly double C1 = 1.19; // "vormfactor" front [-]
        private readonly double C2 = 1.19; // "vormfactor" rear [-]
        private readonly double K1;
        private readonly double K2;
        private readonly double B1; // Stiffness factor front
        private readonly double B2; // Stiffness factor rear
        private readonly double E1; // curvature factor front
        private readonly double E2; // curvature factor rear
        private readonly double Cy1; // Tyre stiffness front [N/rad]
        private readonly double Cy2; // Tyre stiffness rear [N/rad]
        private readonly double forwardVelocity; // [m/s]
        private readonly double yawFactor; // steering factor [deg]

        private Tyre tyre;
        private Forces forces;
        private Movement movement;
        private Position position;

        public CarBehaviour()
        {
            // Pre-defined input from voertuigdata.m
            mass = 1150;
            gravity = 9.81;
            lengthWheelbase = 2.66;
            lengthFront = 1.06;
            lengthRear = lengthWheelbase - lengthFront;
            inertiaMoment = 1850;
            ETA = 0.03;
            Fz0 = 8000;
            Fz1 = mass * gravity * lengthRear / lengthWheelbase;
            Fz2 = mass * gravity * lengthFront / lengthWheelbase;
            dFz1 = (Fz1 - Fz0) / Fz0;
            dFz2 = (Fz2 - Fz0) / Fz0;
            mu1 = 0.9;
            mu2 = 0.9;
            D1 = mu1 * (-0.145 * dFz1 + 0.99) * Fz1;
            D2 = mu2 * (-0.145 * dFz2 + 0.99) * Fz2;
            C1 = 1.19;
            C2 = 1.19;
            K1 = 14.95 * Fz0 * Math.Sin(2 * Math.Atan(Fz1 / 2.13 / Fz0));
            K2 = Fz2 * K1 / (Fz1 - ETA - K1);
            B1 = K1 / C1 / D1;
            B2 = K2 / C2 / D2;
            E1 = -1.003 - 0.537 * dFz1;
            E2 = -1.003 - 0.537 * dFz2;
            Cy1 = B1 * C1 * D1;
            Cy2 = B2 * C2 * D2;
            forwardVelocity = 80 / 3.6;
            yawFactor = 2;
        }

        /// <summary>
        ///     Lateral velocity for current iteration
        /// </summary>
        private readonly double lateralVelocity;

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

        private double previousDisplacementY;

        /// <summary>
        ///     Steer angle in radians. Input from steering wheel
        ///     Should not be greater than 30 degrees = Pi/6
        /// </summary>
        /// 
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

        public void CarBehaviourOLDCONSTRUCTOR()
        {
            SteerAngleRadians = 0.00;

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
            previousFyTotal = previousMzTotal = previousYawVelocity = lateralVelocity = previousLateralVelocity = previousDisplacementY=  0;

            // Object creation initialization
            tyre = new Tyre(mass, gravity, length, SteerAngleRadians, yawVelocityRadians, lateralVelocity, a, b, fz0, forwardVelocity);
            forces = new Forces(tyre.TyreForceFront(), tyre.TyreForceRear(), a, b);
            movement = new Movement(forces.FyTotal(), forces.MzMoment(), I, mass, previousFyTotal, previousMzTotal, dt,
                forwardVelocity, previousYawVelocity, previousLateralVelocity);
            position = new Position(forwardVelocity, previousForwardVelocity, yawVelocity(), 
            previousYawVelocity, lateralVelocity, previousLateralVelocity, dt, previousDisplacementY);
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

            forces.TyreForceFront = tyre.TyreForceFront();
            forces.TyreForceRear = tyre.TyreForceRear();

            movement.CurrentFyTotal = forces.FyTotal();
            movement.CurrentMzTotal = forces.MzMoment();

            movement.PreviousLateralVelocity = previousLateralVelocity;
            movement.PreviousYawVelocity = previousYawVelocity;
            // Save the current values for future iterations (needed for integration)
            previousFyTotal = movement.CurrentFyTotal;
            previousMzTotal = movement.CurrentMzTotal;

            // Initialized here because we need output 
            position.CurrentYawVelocity = yawVelocity();
            position.CurrentLateralVelocity = lateralVelocity;
            position.PreviousDisplacementY = previousDisplacementY;

            //Save the current values for future iterations (needed for integration)
            previousForwardVelocity = position.CurrentForwardVelocity;
            previousLateralVelocity = movement.lateralVelocity();
            previousYawVelocity = movement.yawVelocity();

            // Update X and Y coordinates based on calculated displacement
            double vehicleDisplacementX = position.displacementX();
            double vehicleDisplacementY = position.displacementY();
            xCoordinate += Math.Cos(steerAngleDegrees()) * vehicleDisplacementX + Math.Sin(steerAngleDegrees())*vehicleDisplacementY;
            yCoordinate += Math.Sin(steerAngleDegrees())* vehicleDisplacementX - Math.Cos(steerAngleDegrees())*vehicleDisplacementY;

            previousDisplacementY = position.displacementY();
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