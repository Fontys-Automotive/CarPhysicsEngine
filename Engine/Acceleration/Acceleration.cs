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
            PowerTrain.CalculateRPM();
            PowerTrain.CalculateTorque();
            PowerTrain.CalculateDeliveredDrivingPower();

            // Vehicle Model
            VehicleModel.DeltaT = DeltaT;
            VehicleModel.DeliveredDrivingPower = PowerTrain.DeliveredDrivingPower;

            VehicleModel.CalculateAirResistance();
            VehicleModel.CalculateRollingResistance();
            VehicleModel.CalculateSumForces();

            VehicleModel.CalculateForwardVelocity();

            ForwardVelocityOutput = VehicleModel.CurrentForwardVelocity;
        }
    }
}