﻿using System;

namespace CarPhysicsEngine
{
    internal class Position
    {
        private readonly double dt;

        public Position(double currentForwardVelocity, double previousForwardVelocity, double currentYawVelocity,
            double previousYawVelocity, double currentLateralVelocity, double previousLateralVelocity, double dt)
        {
            CurrentForwardVelocity = currentForwardVelocity;
            PreviousForwardVelocity = previousForwardVelocity;
            CurrentYawVelocity = currentYawVelocity;
            PreviousYawVelocity = previousYawVelocity;
            CurrentLateralVelocity = currentLateralVelocity;
            PreviousLateralVelocity = previousLateralVelocity;
            this.dt = dt;
        }

        public double CurrentForwardVelocity { get; private set; }
        public double PreviousForwardVelocity { get; private set; }
        public double CurrentYawVelocity { get; private set; }
        public double PreviousYawVelocity { get; private set; }
        public double CurrentLateralVelocity { get; private set; }
        public double PreviousLateralVelocity { get; private set; }

        private double yawVelocityIntegral
        {
            get { return (CurrentYawVelocity - PreviousYawVelocity) * dt; }
        }

        /// <summary>
        ///     Calculation of the new X position
        /// </summary>
        /// <returns></returns>
        public double X()
        {
            var n1 = Math.Cos(yawVelocityIntegral) * CurrentForwardVelocity;
            var n2 = CurrentLateralVelocity * Math.Sin(yawVelocityIntegral);
            var n3 = n1 - n2;

            var m1 = Math.Cos(yawVelocityIntegral) * PreviousForwardVelocity;
            var m2 = PreviousLateralVelocity * Math.Sin(yawVelocityIntegral);
            var m3 = m1 - m2;

            return (n3 - m3) * dt;
        }

        /// <summary>
        ///     Calculation of the new Y position
        /// </summary>
        /// <returns></returns>
        public double Y()
        {
            var n1 = CurrentForwardVelocity * Math.Sin(yawVelocityIntegral);
            var n2 = CurrentLateralVelocity * Math.Cos(yawVelocityIntegral);
            var n3 = n1 + n2;

            var m1 = PreviousForwardVelocity * Math.Sin(yawVelocityIntegral);
            var m2 = PreviousLateralVelocity * Math.Cos(yawVelocityIntegral);
            var m3 = m1 + m2;

            return (n3 - m3) * dt;
        }
    }
}