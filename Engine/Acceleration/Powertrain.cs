using System;
using System.Collections.Generic;
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
        public double Rpm { get; private set; }
        public double Transmission { get; private set; }
        public double DeliveredDrivingPower { get; private set; }
        
        private double throttlePercentage;

        /// <summary>
        ///     Output of Acceleration Lookup Table in MATLAB Model
        /// </summary>
        public void CalculateGear()
        {
            var lowerLimit = Setup.Gear.Keys.First();
            var upperLimit = Setup.Gear.Keys.Last();

            if (ForwardVelocityInput <= lowerLimit)
                Gear = Setup.Gear[lowerLimit];
            if (ForwardVelocityInput >= upperLimit)
                Gear = Setup.Gear[upperLimit];

            var keys = Setup.Gear.Keys.ToArray();

            for (var i = 0; i < keys.Count() - 1; i++)
            {
                if (ForwardVelocityInput >= keys[i] && ForwardVelocityInput <= keys[i + 1])
                {
                    Gear = Setup.Gear[keys[i]];
                    break;
                }
            }
        }

        /// <summary>
        ///     Output of Transmission Lookup Table in MATLAB Model
        /// </summary>
        /// <returns>Transmission</returns>
        public void CalculateTransmission()
        {
            Transmission = Setup.Transmission[Gear];
        }

        /// <summary>
        ///     Output Forward Velocity (new)
        /// </summary>
        /// <returns></returns>
        public void CalculateRpm()
        {
            Rpm = ForwardVelocityInput * 60 / (2 * Math.PI * Setup.R) * Transmission;
        }

        /// <summary>
        ///     Output of Maximum Torque Lookup Table in MATLAB Model
        /// </summary>
        public void CalculateTorque()
        {
            SetRpmAndThrottle();
            
            var engineTorqueKey = new Setup.EngineTorqueKey(Rpm, throttlePercentage);

            //Torque = Setup.EngineTorque[engineTorqueKey];
            /*if (ForwardVelocityInput <= 0 && ThrottleInput == 0)
                Torque = 0;*/
        }

        /// <summary>
        ///     Set appropriate RPM and Throttle Percentage values based on Lookup Table
        /// </summary>
        private void SetRpmAndThrottle()
        {
            // Save the Throttle Input locally because we can't change the pedal press
            throttlePercentage = ThrottleInput;

            // Get list of possible RPM and Throttle Percentage values
            var possibleRpm = new List<double>();
            var possibleThrottle = new List<double>();

            foreach (var key in Setup.EngineTorque.Keys)
            {
                possibleRpm.Add(key.RPM);
                possibleThrottle.Add(key.ThrottlePercentage);
            }

            possibleRpm = possibleRpm.Distinct().ToList();
            possibleThrottle = possibleThrottle.Distinct().ToList();

            Rpm = Helpers.SaturationDynamic(possibleRpm.First(), possibleRpm.Last(), Rpm);
            throttlePercentage = Helpers.SaturationDynamic(possibleThrottle.First(), possibleThrottle.Last(), throttlePercentage);

            // - calculate upper and lower, RPM and throttle values
            // - calculate step for rpm at upper/lower throttle
            double lowerRpm, upperRpm, lowerThrottle, upperThrottle;
            lowerRpm = upperRpm = lowerThrottle = upperThrottle = 0;

            

            // ======= 
            
            // Get upper and lower throttle
            for (var i = 0; i < possibleThrottle.Count() - 1; i++)
            {
                if (throttlePercentage >= possibleThrottle[i] && throttlePercentage < possibleThrottle[i + 1])
                {
                    lowerThrottle = possibleThrottle[i];
                    upperThrottle = possibleThrottle[i + 1];
                }
            }
            
            // Get upper and lower RPM
            for (var i = 0; i < possibleRpm.Count() - 1; i++)
            {
                if (Rpm >= possibleRpm[i] && Rpm < possibleRpm[i + 1])
                {
                    lowerRpm = possibleRpm[i];
                    upperRpm = possibleRpm[i + 1];
                    break;
                }
            }

            var torqueLowerRpmLowerThrottle = Setup.EngineTorque[new Setup.EngineTorqueKey(lowerRpm, lowerThrottle)];
            var torqueLowerRpmUpperThrottle = Setup.EngineTorque[new Setup.EngineTorqueKey(lowerRpm, upperThrottle)];
            var torqueUpperRpmLowerThrottle = Setup.EngineTorque[new Setup.EngineTorqueKey(upperRpm, lowerThrottle)];
            var torqueUpperRpmUpperThrottle = Setup.EngineTorque[new Setup.EngineTorqueKey(upperRpm, upperThrottle)];

            var rpmStepLowerThrottle = (torqueUpperRpmLowerThrottle - torqueLowerRpmLowerThrottle) / (upperRpm - lowerRpm);
            var rpmStepUpperThrottle = (torqueUpperRpmUpperThrottle - torqueLowerRpmUpperThrottle) / (upperRpm - lowerRpm);

            var throttleStepLowerRpm = (torqueLowerRpmUpperThrottle - torqueLowerRpmLowerThrottle) / (upperThrottle - lowerThrottle);
            var throttleStepUpperRpm = (torqueUpperRpmUpperThrottle - torqueUpperRpmLowerThrottle) / (upperThrottle - lowerThrottle);

            var n1 = Setup.EngineTorque[new Setup.EngineTorqueKey(lowerRpm,lowerThrottle)]+ (Rpm - lowerRpm) * rpmStepLowerThrottle;
            var n2 = Setup.EngineTorque[new Setup.EngineTorqueKey(lowerRpm, lowerThrottle)]+(throttlePercentage - lowerThrottle) * throttleStepLowerRpm;
            var avg = (n1 + n2) / 2;
            Torque = avg;
        }


        public void CalculateDeliveredDrivingPower()
        {
            DeliveredDrivingPower =  (Torque * Transmission) / Setup.R;
        }
    }
}