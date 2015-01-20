using System;

namespace CarPhysicsEngine.Acceleration
{
    public class VehicleModel
    {
        public double DeliveredDrivingPower { private get; set; }
        private double PreviousForwardVelocity { get; set; }
        public double CurrentForwardVelocity { get; set; }
        public double DeltaT { private get; set; }

        private double AirResistance { get; set; }
        private double SumForces { get; set; }

        public void CalculateForwardVelocity()
        {
            PreviousForwardVelocity = CurrentForwardVelocity;

            var saturationOutput = Helpers.SaturationDynamic(NegativeFriction, PositiveFriction, SumForces);
            var n1 = saturationOutput / Setup.M;

            CurrentForwardVelocity = n1 * DeltaT;
        }

        private static double PositiveFriction
        {
            get { return Setup.MuMax * Setup.M * Setup.G; }
        }

        private static double NegativeFriction
        {
            get { return PositiveFriction * -1; }
        }

        public void CalculateAirResistance()
        {
            AirResistance = (Math.Pow(PreviousForwardVelocity, 2) * Setup.Rho * Setup.Cw * Setup.A) / 2;
        }

        public void CalculateSumForces()
        {
            SumForces = DeliveredDrivingPower - AirResistance;
        }
    }
}