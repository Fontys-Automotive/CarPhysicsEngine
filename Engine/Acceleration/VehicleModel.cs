using System;

namespace CarPhysicsEngine.Acceleration
{
    public class VehicleModel
    {
        
        public double DeliveredDrivingPower { private get; set; }
        public double BoundaryDrivingPower { private get; set; }
        public double PreviousForwardVelocity { get; set; }
        public double CurrentForwardVelocity { get; set; }
        private static double PositiveFriction
        {
            get { return Setup.Cw * Setup.M * Setup.G; }
        }

        private static double NegativeFriction
        {
            get { return PositiveFriction * -1; }
        }

        private static double RollingResistance
        {
            get { return Setup.Fr * Setup.M * Setup.G; }
        }

        public VehicleModel()
        {
            DeliveredDrivingPower = 0;
            BoundaryDrivingPower = 10000;
        }
        private double AirResistance()
        {
            return (Math.Pow(PreviousForwardVelocity, 2) * Setup.Rho * Setup.Cw * Setup.A) / 2;
        }

        public void ForwardVelocity()
        {
           var saturationOutput = Helpers.SaturationDynamic(NegativeFriction, PositiveFriction, SumForces());
           var n1 = saturationOutput / Setup.M;
           // !TODO get DeltaT from CarBehaviour
           // var velocity = n1 * Setup.DeltaT;

<<<<<<< HEAD
            CurrentForwardVelocity = velocity;
            PreviousForwardVelocity = CurrentForwardVelocity;


=======
           // return velocity;
            return 0;
>>>>>>> bugfix-deltaT
        }

        public double SumForces()
        {
            var drivingPower = Helpers.SaturationDynamic(-10000, BoundaryDrivingPower, DeliveredDrivingPower);
            return drivingPower - (AirResistance() + RollingResistance);

        }

        public double Displacement()
        {
<<<<<<< HEAD
            return CurrentForwardVelocity * Setup.DeltaT;
=======
            // !TODO get DeltaT from CarBehaviour
            // return ForwardVelocity() * Setup.DeltaT;
            return 0;
>>>>>>> bugfix-deltaT
        }

    }
}