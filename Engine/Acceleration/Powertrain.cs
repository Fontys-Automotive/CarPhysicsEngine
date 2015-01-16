using System;
using System.Collections.Generic;
using System.Linq;

namespace CarPhysicsEngine.Acceleration
{
    public class Powertrain
    {
        public double ForwardVelocityInput { get; set; }
        public double ForwardVelocityOutput { get; set; }

        public double Gear { get; set; }
        public double GearRatio { get; set; }

        public double TorqueInput { get; set; }
        public double TorqueOutput { get; set; }

        public double ThrottleInput { get; set; }
        public double DrivingPowerOutput { get; set; }

        public void CalculateGear()
        {
            for (int i = 0; i < Setup.SwitchingBehaviour.Count; i++)
            {
                if (ForwardVelocityInput >= Setup.SwitchingBehaviour.Keys.ElementAt(i) && ForwardVelocityInput < Setup.SwitchingBehaviour.Keys.ElementAt(i + 1))
                {
                    Gear = Setup.SwitchingBehaviour[Setup.SwitchingBehaviour.Keys.ElementAt(i)];
                }
            }
        }
        public void CalculateTransmission()
        {
            GearRatio = Setup.GearRatio[Gear];
        }

        public void CalculateTorqueInput()
        {
            var wheelTurn = ForwardVelocityInput * (60 / (2 * Math.PI * Setup.R));
            TorqueInput = wheelTurn * GearRatio;
        }

        public void CalculateDrivingPower()
        {
            for (int i = 0; i < Setup.EngineTorque.Count; i++)
            {
                if (ForwardVelocityInput >= Setup.EngineTorque.Keys.ElementAt(i) && ForwardVelocityInput < Setup.EngineTorque.Keys.ElementAt(i + 1))
                {
                    Gear = Setup.EngineTorque[Setup.EngineTorque.Keys.ElementAt(i)];
                }
            }
            TorqueOutput = Setup.EngineTorque[new Setup.EngineTorqueKey(TorqueInput, ThrottleInput)];
            DrivingPowerOutput = TorqueOutput / Setup.R;
        }
    }
}