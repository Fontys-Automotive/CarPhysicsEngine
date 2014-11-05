using System;

namespace CarPhysicsEngine
{
    public class Position
    {
        private readonly double dt;

        public Position(double currentForwardVelocity, double previousForwardVelocity, double currentYawVelocity,
            double previousYawVelocity, double currentLateralVelocity, double previousLateralVelocity, double dt, double previousDisplacementY)
        {
            CurrentForwardVelocity = currentForwardVelocity;
            PreviousForwardVelocity = previousForwardVelocity;
            CurrentYawVelocity = currentYawVelocity;
            PreviousYawVelocity = previousYawVelocity;
            CurrentLateralVelocity = currentLateralVelocity;
            PreviousLateralVelocity = previousLateralVelocity;
            PreviousDisplacementY = previousDisplacementY;
            this.dt = dt;
        }

        public double CurrentForwardVelocity { get;  set; }
        public double PreviousForwardVelocity { get; private set; }
        public double CurrentYawVelocity { get;  set; }
        public double PreviousYawVelocity { get; private set; }
        public double CurrentLateralVelocity { get;  set; }
        public double PreviousLateralVelocity { get; private set; }
        public double PreviousDisplacementY { get; set; }

        private double yawVelocityIntegral
        {
            get { return (CurrentYawVelocity - PreviousYawVelocity) * dt; }
        }

        /// <summary>
        ///     Calculation of the new displacementX position
        /// </summary>
        /// <returns></returns>
        public double displacementX()
        {
            var n1 = Math.Cos(yawVelocityIntegral) * CurrentForwardVelocity;
            var n2 = CurrentLateralVelocity * Math.Sin(yawVelocityIntegral);
            var n3 = n1 - n2;

            // !TODO: Modify for variable acceleration
            //var m1 = Math.Cos(yawVelocityIntegral) * PreviousForwardVelocity;
            //var m2 = PreviousLateralVelocity * Math.Sin(yawVelocityIntegral);
            //var m3 = m1 - m2;

            return n3 * dt;
        }

        /// <summary>
        ///     Calculation of the new displacementY position
        /// </summary>
        /// <returns></returns>
        public double displacementY()
        {
            var n1 = CurrentForwardVelocity * Math.Sin(yawVelocityIntegral);
            var n2 = CurrentLateralVelocity * Math.Cos(yawVelocityIntegral);
            var n3 = n1 + n2;

            // !TODO: Modify for variable acceleration
            //var m1 = PreviousForwardVelocity * Math.Sin(yawVelocityIntegral);
            //var m2 = PreviousLateralVelocity * Math.Cos(yawVelocityIntegral);
            //var m3 = m1 + m2;

            return (n3 * dt);
        }
    }
}