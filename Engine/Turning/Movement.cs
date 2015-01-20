namespace CarPhysicsEngine.Turning
{
    public class Movement
    {
        public double ForwardVelocity { private get; set; }

        public double FyTotal { get; set; }
        public double MzTotal { get; set; }
        public double DeltaT { private get; set; }
        public double PreviousLateralVelocity { private get; set; }
        public double PreviousYawVelocity { private get; set; }

        /// <summary>
        /// Calculates the new YawVelocity by adding the change of YawVelocity for one time step.
        /// Will not change , while there is no change of the steerangle.
        /// </summary>
        /// <returns></returns>
        public double YawVelocity()
        {
            return PreviousYawVelocity + DeltaT * (MzTotal / Setup.InertiaMoment);
        }

        /// <summary>
        /// Calculates Lateral Acceleration with the current Forces. 
        /// Will drop to zero, if there is no change of the steerangle. 
        /// </summary>
        public double LateralAcceleration()
        {
            return (FyTotal / Setup.M) - (YawVelocity() * ForwardVelocity);
        }

        /// <summary>
        /// Calculates the lateral (side) velocity
        /// </summary>
        /// <returns></returns>
        public double LateralVelocity()
        {
            return PreviousLateralVelocity + DeltaT * LateralAcceleration();
        }
    }
}