using System;
using System.Linq;

namespace CarPhysicsEngine.Acceleration
{
    public class Powertrain
    {
        /// <summary>
        ///     Forward Velocity at Start of Iteration
        /// </summary>
        public double ForwardVelocityInput { private get; set; }

        /// <summary>
        ///     Throttle Input from pedals
        /// </summary>
        public double ThrottleInput { private get; set; }

        public double Gear { get; private set; }
        public double Torque { get; private set; }
        public double RPM { get; private set; }
        public double Transmission { get; private set; }
        public double DeliveredDrivingPower { get; private set; }

        private double rpm;
        private double throttlePercentage;

        /// <summary>
        ///     Output of Acceleration Lookup Table in MATLAB Model
        /// </summary>
        public void CalculateGear()
        {
            var lowerLimit = Setup.SwitchingBehaviour.Keys.First();
            var upperLimit = Setup.SwitchingBehaviour.Keys.Last();

            if (ForwardVelocityInput <= lowerLimit)
                Gear = Setup.SwitchingBehaviour[lowerLimit];
            if (ForwardVelocityInput >= upperLimit)
                Gear = Setup.SwitchingBehaviour[upperLimit];

            var keys = Setup.SwitchingBehaviour.Keys.ToArray();

            for (var i = 0; i < keys.Count() - 1; i++)
            {
                if (ForwardVelocityInput >= keys[i] && ForwardVelocityInput <= keys[i + 1])
                {
                    Gear = Setup.SwitchingBehaviour[keys[i]];
                    break;
                }
            }
        }

        /// <summary>
        ///     Output of Maximum Torque Lookup Table in MATLAB Model
        /// </summary>
        public void CalculateTorque()
        {
            SetInputVelocityAndThrottle();
            
            var engineTorqueKey = new Setup.EngineTorqueKey(rpm, throttlePercentage);

            Torque = Setup.EngineTorque[engineTorqueKey];
        }

        /// <summary>
        ///     !TODO HACK!
        /// </summary>
        private void SetInputVelocityAndThrottle()
        {
            rpm = RPM;
            throttlePercentage = ThrottleInput;

            var possibleRPM = new double[] { 1400, 1900, 2400, 2900, 3300, 3800, 4000, 4200, 4500, 5000, 5400, 5800, 6000 };
            var possibleThrottlePercentage = new double[] { 0, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            if (rpm <= possibleRPM[0])
                rpm = possibleRPM[0];
            if (rpm >= possibleRPM[possibleRPM.Count() - 1])
                rpm = possibleRPM[possibleRPM.Count() - 1];
            for (var i = 0; i < possibleRPM.Count() - 1; i++)
            {
                if (rpm >= possibleRPM[i] && rpm < possibleRPM[i + 1])
                    rpm = possibleRPM[i];
            }

            if (throttlePercentage <= possibleThrottlePercentage[0])
                throttlePercentage = possibleThrottlePercentage[0];
            if (throttlePercentage >= possibleThrottlePercentage[possibleThrottlePercentage.Count() - 1])
                throttlePercentage = possibleThrottlePercentage[possibleThrottlePercentage.Count() - 1];
            for (var i = 0; i < possibleThrottlePercentage.Count() - 1; i++)
            {
                if (throttlePercentage >= possibleThrottlePercentage[i] && throttlePercentage < possibleThrottlePercentage[i + 1])
                    throttlePercentage = possibleThrottlePercentage[i];
            }
        }

        /// <summary>
        ///     Output Forward Velocity (new)
        /// </summary>
        /// <returns></returns>
        public void CalculateRPM()
        {
            RPM = ForwardVelocityInput * 60 / (2 * Math.PI * Setup.R) * Transmission;
        }

        /// <summary>
        ///     Output of Transmission Lookup Table in MATLAB Model
        /// </summary>
        /// <returns>Transmission</returns>
        public void CalculateTransmission()
        {
            Transmission = Setup.GearRatio[Gear];
        }

        public void CalculateDeliveredDrivingPower()
        {
            DeliveredDrivingPower =  (Torque * Transmission) / Setup.R;
        }
    }
}