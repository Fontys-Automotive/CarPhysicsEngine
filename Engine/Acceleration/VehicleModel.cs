using System;

namespace CarPhysicsEngine.Acceleration
{
    public class VehicleModel
    {
        
        public double DeliveredDrivingPower { private get; set; }
        public double BoundaryDrivingPower { private get; set; }

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
            BoundaryDrivingPower = 0;
        }
        private double AirResistance()
        {
            return (Math.Pow(ForwardVelocity(), 2) * Setup.Rho * Setup.Cw * Setup.A) / 2;
        }

        public double ForwardVelocity()
        {
           var saturationOutput = Helpers.SaturationDynamic(NegativeFriction, PositiveFriction, SumForces());
           var n1 = saturationOutput / Setup.M;
           // !TODO get DeltaT from CarBehaviour
           // var velocity = n1 * Setup.DeltaT;

           // return velocity;
            return 0;
        }

        public double SumForces()
        {
            var drivingPower = Helpers.SaturationDynamic(-10000, BoundaryDrivingPower, DeliveredDrivingPower);
            return drivingPower - (AirResistance() + RollingResistance);

        }

        public double Displacement()
        {
            // !TODO get DeltaT from CarBehaviour
            // return ForwardVelocity() * Setup.DeltaT;
            return 0;
        }

    }
}