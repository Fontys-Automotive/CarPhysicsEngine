using System;

namespace CarPhysicsEngine.Acceleration
{
    public class VehicleModel
    {
        public double DeliveredDrivingPower { private get; set; }
        public double CurrentForwardVelocity { get; private set; }
        public double DeltaT { private get; set; }

        private double AirResistance { get; set; }
        private double RollingResistance { get; set; }
        private double SumForces { get; set; }

        public void CalculateForwardVelocity()
        {
            var saturationOutput = Helpers.SaturationDynamic(NegativeFriction, PositiveFriction, SumForces);
            var n1 = saturationOutput / Setup.M;

            CurrentForwardVelocity += n1 * DeltaT;
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
            AirResistance = (Math.Pow(CurrentForwardVelocity, 2) * Setup.Rho * Setup.Cw * Setup.A) / 2;
        }

        public void CalculateRollingResistance()
        {
            RollingResistance = Setup.Fr * Setup.M * Setup.G;
        }

        public void CalculateSumForces()
        {
            SumForces = DeliveredDrivingPower - AirResistance - RollingResistance;
        }
    }
}