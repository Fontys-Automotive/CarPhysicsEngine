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

            // Remove duplicates from lists
            possibleRpm = possibleRpm.Distinct().ToList();
            possibleThrottle = possibleThrottle.Distinct().ToList();

            // Ensure that RPM and Throttle Percentage are within limits
            Rpm = Helpers.SaturationDynamic(possibleRpm.First(), possibleRpm.Last(), Rpm);
            throttlePercentage = Helpers.SaturationDynamic(possibleThrottle.First(), possibleThrottle.Last(), throttlePercentage);

            // - calculate upper and lower, RPM and throttle values
            // - calculate step for rpm at upper/lower throttle
            double lowerRpmBreakpoint, upperRpmBreakpoint, lowerThrottleBreakpoint, upperThrottleBreakpoint;
            lowerRpmBreakpoint = upperRpmBreakpoint = lowerThrottleBreakpoint = upperThrottleBreakpoint = 0;

            // Identify previous and next RPM breakpoints
            for (var i = 0; i < possibleRpm.Count() - 1; i++)
            {
                if (!(Rpm >= possibleRpm[i]) ||
                    !(Rpm < possibleRpm[i + 1]))
                    continue;

                lowerRpmBreakpoint = possibleRpm[i];
                upperRpmBreakpoint = possibleRpm[i + 1];

                break;
            }

            // Identify previous and next throttle breakpoints
            for (var i = 0; i < possibleThrottle.Count() - 1; i++)
            {
                if (!(throttlePercentage >= possibleThrottle[i]) ||
                    !(throttlePercentage < possibleThrottle[i + 1]))
                    continue;

                lowerThrottleBreakpoint = possibleThrottle[i];
                upperThrottleBreakpoint = possibleThrottle[i + 1];

                break;
            } 

            // Get torque values for RPM-Throttle bounds
            var torqueForLowerRpmLowerThrottle = Setup.EngineTorque[new Setup.EngineTorqueKey(lowerRpmBreakpoint, lowerThrottleBreakpoint)];
            var torqueForLowerRpmUpperThrottle = Setup.EngineTorque[new Setup.EngineTorqueKey(lowerRpmBreakpoint, upperThrottleBreakpoint)];
            var torqueForUpperRpmLowerThrottle = Setup.EngineTorque[new Setup.EngineTorqueKey(upperRpmBreakpoint, lowerThrottleBreakpoint)];
            var torqueForUpperRpmUpperThrottle = Setup.EngineTorque[new Setup.EngineTorqueKey(upperRpmBreakpoint, upperThrottleBreakpoint)];

            // Calculate RPM and Throttle Step
            var rpmStepForThrottle = (torqueForLowerRpmUpperThrottle - torqueForLowerRpmLowerThrottle) /
                                     (upperThrottleBreakpoint - lowerThrottleBreakpoint);
            var torqueStepForThrottle = (torqueForUpperRpmLowerThrottle - torqueForLowerRpmLowerThrottle) /
                                        (upperRpmBreakpoint - lowerRpmBreakpoint);

            
            var torqueDifference = (Rpm - lowerRpmBreakpoint) * torqueStepForThrottle +
                                   (throttlePercentage - lowerThrottleBreakpoint) * rpmStepForThrottle;

            Torque = torqueForLowerRpmLowerThrottle + torqueDifference;
        }


        public void CalculateDeliveredDrivingPower()
        {
            DeliveredDrivingPower =  (Torque * Transmission) / Setup.R;
        }
    }
}