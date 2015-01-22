using System;

namespace CarPhysicsEngine.Acceleration
{
    public class VehicleModel
    {
        public double DeliveredDrivingPower { private get; set; }
        public double CurrentForwardVelocity { get; set; }
        public double DeltaT { private get; set; }
        public double BrakeInput { private get; set; }
        public double ForwardAcceleration { get; private set; }
        public double BrakeForce { get; private set; }

        private double AirResistance { get; set; }
        private double RollingResistance { get; set; }
        private double SumForces { get; set; }

        public void CalculateForwardVelocity()
        {
            var saturationOutput = Helpers.SaturationDynamic(NegativeFriction, PositiveFriction, SumForces);
            ForwardAcceleration = saturationOutput / Setup.M;

            CurrentForwardVelocity += ForwardAcceleration * DeltaT;
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

        public void CalculateBraking()
        {
            const double saturationLimit = 5.0 / 15.0;
            var n1 = (BrakeInput) * 42.1 / Setup.R;
            var n2 = CurrentForwardVelocity / Setup.R;
            var n3 = Helpers.SaturationDynamic(-saturationLimit, saturationLimit, n2);

            BrakeForce = n1 * n3;
        }

        public void CalculateSumForces()
        {
            SumForces = DeliveredDrivingPower - (AirResistance + RollingResistance + BrakeForce);
        }
    }
}