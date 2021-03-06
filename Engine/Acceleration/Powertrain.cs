﻿using System;
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
            Rpm = ForwardVelocityInput * (60 / (2 * Math.PI * Setup.R)) * Transmission;
        }

        /// <summary>
        ///     Output of Maximum Torque Lookup Table in MATLAB Model
        /// </summary>
        public void CalculateTorque()
        {
            // Save the Throttle Input locally because we can't change the pedal press
            var throttlePercentage = ThrottleInput;

            // Get list of possible RPM and Throttle Percentage values
            var possibleRpm = new List<double>();
            var possibleThrottle = new List<double>();

            foreach (var key in Setup.EngineTorque.Keys)
            {
                possibleRpm.Add(key.Rpm);
                possibleThrottle.Add(key.ThrottlePercentage);
            }

            // Remove duplicates from lists
            possibleRpm = possibleRpm.Distinct().ToList();
            possibleThrottle = possibleThrottle.Distinct().ToList();

            // Ensure that RPM and Throttle Percentage are within limits
            Rpm = Helpers.SaturationDynamic(possibleRpm.First(), possibleRpm.Last(), Rpm);
            throttlePercentage = Helpers.SaturationDynamic(possibleThrottle.First(), possibleThrottle.Last(), throttlePercentage);

            // If Max RPM and Max Throttle
            if (Rpm.Equals(possibleRpm.Last()) && throttlePercentage.Equals(possibleThrottle.Last()))
            {
                Torque = Setup.EngineTorque[new Setup.EngineTorqueKey(Rpm, throttlePercentage)];

                return;
            }

            // If Max RPM
            if (Rpm.Equals(possibleRpm.Last()))
            {
                CalculateTorqueForConstantRpmOrThrottle(possibleThrottle, Rpm, throttlePercentage, isRpm: true);

                return;

            }

            // If Max Throttle
            if (throttlePercentage.Equals(possibleThrottle.Last()))
            {
                CalculateTorqueForConstantRpmOrThrottle(possibleRpm, throttlePercentage, Rpm, isRpm: false);

                return;
            }

            // Calculate RPM and Throttle Breakpoints
            var upperRpmBreakpoint = possibleRpm.Find(x => Rpm < x);
            var lowerRpmBreakpoint = possibleRpm[possibleRpm.IndexOf(upperRpmBreakpoint) - 1];

            var upperThrottleBreakpoint = possibleThrottle.Find(x => throttlePercentage < x);
            var lowerThrottleBreakpoint = possibleThrottle[possibleThrottle.IndexOf(upperThrottleBreakpoint) - 1];

            // Get torque values for RPM-Throttle bounds
            var torqueForLowerRpmLowerThrottle = Setup.EngineTorque[new Setup.EngineTorqueKey(lowerRpmBreakpoint, lowerThrottleBreakpoint)];
            var torqueForLowerRpmUpperThrottle = Setup.EngineTorque[new Setup.EngineTorqueKey(lowerRpmBreakpoint, upperThrottleBreakpoint)];
            var torqueForUpperRpmLowerThrottle = Setup.EngineTorque[new Setup.EngineTorqueKey(upperRpmBreakpoint, lowerThrottleBreakpoint)];
            var torqueForUpperRpmUpperThrottle = Setup.EngineTorque[new Setup.EngineTorqueKey(upperRpmBreakpoint, upperThrottleBreakpoint)];

            // Interpolation
            var torqueRpmInterpolation = torqueForLowerRpmLowerThrottle +
                      (torqueForUpperRpmLowerThrottle - torqueForLowerRpmLowerThrottle) /
                      (upperRpmBreakpoint - lowerRpmBreakpoint) * (Rpm - lowerRpmBreakpoint);

            var torqueThrottleInterpolation = torqueForLowerRpmUpperThrottle +
                      (torqueForUpperRpmUpperThrottle - torqueForLowerRpmUpperThrottle) /
                      (upperRpmBreakpoint - lowerRpmBreakpoint) * (Rpm - lowerRpmBreakpoint);

            Torque = torqueRpmInterpolation +
                     (torqueThrottleInterpolation - torqueRpmInterpolation) / (upperThrottleBreakpoint - lowerThrottleBreakpoint) *
                     (throttlePercentage - lowerThrottleBreakpoint);
        }


        public void CalculateDeliveredDrivingPower()
        {
            DeliveredDrivingPower =  (Torque * Transmission) / Setup.R;
        }

        /// <summary>
        ///     Calculates the Torque for a variable RPM / Throttle at a constant corresponding RPM/Throttle
        /// </summary>
        /// <param name="possibleValues">List of possible RPM/Throttle Percentages</param>
        /// <param name="constant">RPM or Throttle that is constant</param>
        /// <param name="variable">RPM or Throttle that can change</param>
        /// <param name="isRpm">If constant is RPM</param>
        private void CalculateTorqueForConstantRpmOrThrottle(List<double> possibleValues, double constant, double variable, bool isRpm)
        {
            var upperBreakpoint = possibleValues.Find(x => variable < x);
            var lowerBreakpoint = possibleValues[possibleValues.IndexOf(upperBreakpoint) - 1];

            double torqueForUpperVariable, torqueForLowerVariable;

            if (isRpm)
            {
                torqueForUpperVariable = Setup.EngineTorque[new Setup.EngineTorqueKey(constant, upperBreakpoint)];
                torqueForLowerVariable = Setup.EngineTorque[new Setup.EngineTorqueKey(constant, lowerBreakpoint)];
            }
            else
            {
                torqueForUpperVariable = Setup.EngineTorque[new Setup.EngineTorqueKey(upperBreakpoint, constant)];
                torqueForLowerVariable = Setup.EngineTorque[new Setup.EngineTorqueKey(lowerBreakpoint, constant)];
            }

            var torqueStep = (torqueForUpperVariable - torqueForLowerVariable) /
                             ((upperBreakpoint - lowerBreakpoint) * Setup.PrecisionFactor);

            var torqueDifference = (variable - lowerBreakpoint) * Setup.PrecisionFactor;

            Torque = torqueForLowerVariable + torqueDifference * torqueStep;
        }
    }
}