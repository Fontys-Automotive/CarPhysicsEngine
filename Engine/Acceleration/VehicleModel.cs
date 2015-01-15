using System;

namespace CarPhysicsEngine.Acceleration
{
    public class VehicleModel
    {
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

        private double ForwardVelocity { get; set; }

        private double AirResistance()
        {
            return (Math.Pow(ForwardVelocity, 2) * Setup.Rho * Setup.Cw * Setup.A) / 2;
        }
    }
}