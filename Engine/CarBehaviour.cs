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
        public readonly double ForwardVelocity; // [m/s]
        private readonly double yawFactor; // steering factor [deg]
        private double steerAngle; // steering angle in radians

        private readonly double _deltaT; // time-step in seconds
        private double _previousMzTotal;
        private double _previousFyTotal;
        private double _previousYawVelocity;
        private double _previousLateralVelocity;

        public double YawAngle { get; set; }
        //Max steering angle is set to about 28 degrees(~0,5 rad)
        public double SteerAngle {
            get { return steerAngle; }
            set
            {
                if (value <= 0.5 && value >= -0.5)
                    steerAngle = value;
            }
        }
        public double XCoordinate { get; private set; }
        public double YCoordinate { get; private set; }

        // !TODO: Accessors are public for debugging purposes only. Set to private for production 
        public readonly Tyre Tyre;
        public readonly Forces Forces;
        public readonly Movement Movement;
        public readonly Position Position;

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
            K2 = Fz2 * K1 / (Fz1 - ETA * K1);
            B1 = K1 / C1 / D1;
            B2 = K2 / C2 / D2;
            E1 = -1.003 - 0.537 * dFz1;
            E2 = -1.003 - 0.537 * dFz2;
            Cy1 = B1 * C1 * D1;
            Cy2 = B2 * C2 * D2;
            ForwardVelocity = 80 / 3.6;
            //yawFactor = 2;

            _deltaT = 0.01; // 10 ms
            _previousMzTotal = _previousFyTotal = _previousYawVelocity = _previousLateralVelocity = 0;

            YawAngle = 0;
            SteerAngle = 0.00;
            XCoordinate = YCoordinate = 0;

            Tyre = new Tyre(lengthFront, lengthRear, ForwardVelocity, Cy1, Cy2, SteerAngle);
            Forces = new Forces(lengthFront, lengthRear);
            Movement = new Movement(ForwardVelocity, inertiaMoment, mass, _deltaT);
            Position = new Position(ForwardVelocity, _deltaT, YawAngle);
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
            
            var mz = Forces.MzMoment();
            _previousFyTotal = Movement.FyTotal;
            _previousMzTotal = Movement.MzTotal;
            Movement.FyTotal = Forces.FyTotal();
            Movement.MzTotal = Forces.MzMoment();
            
            

            // Initialize the properties in Position
            Position.PreviousYawVelocity = _previousYawVelocity;
            _previousYawVelocity = Position.YawVelocity = Movement.YawVelocity();
            Position.LateralVelocity = Movement.LateralVelocity();

            // Calculate the new world coordinates for the vehicle
            XCoordinate += Position.VehicleDisplacementX();
            //XCoordinate += Math.Cos(YawAngle) * Position.VehicleDisplacementX()
                           //+ Math.Sin(YawAngle * Position.VehicleDisplacementY());
            YCoordinate += Position.VehicleDisplacementY();
                /*Math.Sin(YawAngle) * Position.VehicleDisplacementX()
                           - Math.Cos(YawAngle) * Position.VehicleDisplacementY();*/

            //Set previous movement values
            Movement.PreviousFyTotal = _previousFyTotal;
            Movement.PreviousMzTotal = _previousMzTotal;
            Movement.PreviousLateralVelocity = Movement.LateralVelocity();
            Movement.PreviousYawVelocity = _previousYawVelocity;

            var newYawAngle = YawAngle + _deltaT * Movement.YawVelocity();
            YawAngle = newYawAngle/* >= -0.6 && newYawAngle <= 0.6 ? newYawAngle : steerAngle*/;
        }

        public double AccelerationY()
        {
            var n1 = Movement.AccelerationY() + (Movement.YawVelocity() * ForwardVelocity);
            return n1 / gravity;
        }

        public double YawVelocity()
        {
            return Movement.YawVelocity() * (180 / Math.PI);
        }

        public double SteerAngleDegrees()
        {
            var n1 = Math.Atan(Movement.LateralVelocity() / ForwardVelocity);
            return n1 * (180 / Math.PI);
        }
    }
}