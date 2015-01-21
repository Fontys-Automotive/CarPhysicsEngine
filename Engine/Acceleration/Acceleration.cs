namespace CarPhysicsEngine.Acceleration
{
    public class Acceleration
    {
        private readonly VehicleModel vehicleModel;
        public readonly Powertrain PowerTrain;

        public double ThrottleInput { private get; set; }
        public double ForwardVelocityInput { private get; set; }
        public double ForwardVelocityOutput { get; private set; }
        public double DeltaT { private get; set; }

        public Acceleration()
        {
            vehicleModel = new VehicleModel();
            PowerTrain = new Powertrain();
        }

        /// <summary>
        ///     Run the Acceleration model
        /// 
        ///     All function calls have been listed here to simplify application flow.
        /// </summary>
        public void Run()
        {
            // Powertrain
            PowerTrain.ThrottleInput = ThrottleInput;
            PowerTrain.ForwardVelocityInput = ForwardVelocityInput;

            PowerTrain.CalculateGear();
            PowerTrain.CalculateTransmission();
            PowerTrain.CalculateRpm();
            PowerTrain.CalculateTorque();
            PowerTrain.CalculateDeliveredDrivingPower();

            // Vehicle Model
            vehicleModel.DeltaT = DeltaT;
            vehicleModel.DeliveredDrivingPower = PowerTrain.DeliveredDrivingPower;

            vehicleModel.CalculateAirResistance();
            vehicleModel.CalculateRollingResistance();
            vehicleModel.CalculateSumForces();

            vehicleModel.CalculateForwardVelocity();

            ForwardVelocityOutput = vehicleModel.CurrentForwardVelocity;
        }
    }
}