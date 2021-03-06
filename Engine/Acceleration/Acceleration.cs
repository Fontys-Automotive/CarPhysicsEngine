﻿namespace CarPhysicsEngine.Acceleration
{
    public class Acceleration
    {
        public readonly VehicleModel VehicleModel;
        public readonly Powertrain PowerTrain;

        public double ThrottleInput { private get; set; }
        public double BrakeInput { private get; set; }
        public double ForwardVelocityInput { private get; set; }
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
        /// <returns>Forward Velocity</returns>
        public double Run()
        {
            // Powertrain
            PowerTrain.ThrottleInput = ThrottleInput;

            PowerTrain.ForwardVelocityInput = ForwardVelocityInput;
            VehicleModel.CurrentForwardVelocity = ForwardVelocityInput;

            PowerTrain.CalculateGear();
            PowerTrain.CalculateTransmission();
            PowerTrain.CalculateRpm();
            PowerTrain.CalculateTorque();
            PowerTrain.CalculateDeliveredDrivingPower();

            // Vehicle Model
            VehicleModel.BrakeInput = BrakeInput;
            VehicleModel.DeltaT = DeltaT;
            VehicleModel.DeliveredDrivingPower = PowerTrain.DeliveredDrivingPower;

            VehicleModel.CalculateAirResistance();
            VehicleModel.CalculateRollingResistance();
            VehicleModel.CalculateBraking();
            VehicleModel.CalculateSumForces();

            VehicleModel.CalculateForwardVelocity();

            return VehicleModel.CurrentForwardVelocity;
        }
    }
}