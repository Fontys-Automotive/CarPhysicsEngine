namespace CarPhysicsEngine.Acceleration
{
    public class Acceleration
    {
        private readonly VehicleModel vehicleModel;
        private readonly Powertrain powerTrain;

        public double ThrottleInput { private get; set; }
        public double ForwardVelocityInput { private get; set; }
        public double OutputForwardVelocity { get; private set; }
        public double DeltaT { private get; set; }

        public Acceleration()
        {
            vehicleModel = new VehicleModel();
            powerTrain = new Powertrain();
        }

        public void Run()
        {
            powerTrain.ForwardVelocityInput = ForwardVelocityInput;
            powerTrain.ThrottleInput = ThrottleInput;

            vehicleModel.CurrentForwardVelocity = powerTrain.ForwardVelocity();
            vehicleModel.DeliveredDrivingPower = powerTrain.DeliveredDrivingPower();
            vehicleModel.DeltaT = DeltaT;

            vehicleModel.ForwardVelocity();

            OutputForwardVelocity = vehicleModel.CurrentForwardVelocity;
        }
    }
}