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
    }
}