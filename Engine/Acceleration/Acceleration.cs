namespace CarPhysicsEngine.Acceleration
{
    public class Acceleration
    {
        private VehicleModel vehicleModel;
        private Powertrain powerTrain;
        public double ThrottleInput { get; set; }
        public double inputForwardVelocity { get; set; }
        public double outputForwardVelocity { get; set; }
        public Acceleration()
        {
            vehicleModel=new VehicleModel();
            powerTrain=new Powertrain();
            ThrottleInput = 0;
        }

        public void Run()
        {
            powerTrain.ForwardVelocityInput = inputForwardVelocity;
            powerTrain.ThrottleInput = ThrottleInput;
            powerTrain.CalculateGear();
            powerTrain.CalculateTransmission();
            powerTrain.CalculateTorqueInput();
            powerTrain.CalculateDrivingPower();

            vehicleModel.DeliveredDrivingPower = powerTrain.DrivingPowerOutput;
            vehicleModel.ForwardVelocity();

            outputForwardVelocity = vehicleModel.CurrentForwardVelocity;



        }
    }
}