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

            vehicleModel.CurrentForwardVelocity = 0;
        }

        public void Run()
        {
            powerTrain.ForwardVelocityInput = ForwardVelocityInput;
            powerTrain.ThrottleInput = ThrottleInput;

            vehicleModel.DeltaT = DeltaT;

            vehicleModel.DeliveredDrivingPower = powerTrain.DeliveredDrivingPower();
            vehicleModel.ForwardVelocity();

            OutputForwardVelocity = vehicleModel.CurrentForwardVelocity;
        }
    }
}