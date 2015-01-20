namespace CarPhysicsEngine.Acceleration
{
    public class Acceleration
    {
        public readonly VehicleModel VehicleModel;
        public readonly Powertrain PowerTrain;

        public double ThrottleInput { private get; set; }
        public double ForwardVelocityInput { private get; set; }
        public double ForwardVelocityOutput { get; private set; }
        public double DeltaT { private get; set; }

        public Acceleration()
        {
            VehicleModel = new VehicleModel();
            PowerTrain = new Powertrain();

            VehicleModel.CurrentForwardVelocity = 0;
        }

        public void Run()
        {
            PowerTrain.ForwardVelocityInput = ForwardVelocityInput;
            PowerTrain.ThrottleInput = ThrottleInput;

            VehicleModel.DeltaT = DeltaT;

            VehicleModel.DeliveredDrivingPower = PowerTrain.DeliveredDrivingPower();
            VehicleModel.ForwardVelocity();

            ForwardVelocityOutput = VehicleModel.CurrentForwardVelocity;
        }
    }
}