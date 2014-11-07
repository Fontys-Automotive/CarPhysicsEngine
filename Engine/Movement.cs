namespace CarPhysicsEngine
{
    public class Movement
    {
        private readonly double _deltaT;
        private readonly double _forwardVelocity;
        private readonly double _inertiaMoment;
        private readonly double _mass;

        public Movement(double forwardVelocity, double inertiaMoment, double mass, double deltaT)
        {
            _forwardVelocity = forwardVelocity;
            _inertiaMoment = inertiaMoment;
            _mass = mass;
            _deltaT = deltaT;
        }

        public double FyTotal { get; set; }
        public double MzTotal { get; set; }
        public double PreviousLateralVelocity { private get; set; }
        public double PreviousYawVelocity { private get; set; }

        /// <summary>
        /// Calculates the new YawVelocity by adding the change of YawVelocity for one time step.
        /// Will not change , while there is no change of the steerangle.
        /// </summary>
        /// <returns></returns>
        public double YawVelocity()
        {
            return PreviousYawVelocity + _deltaT * (MzTotal / _inertiaMoment);
        }

        /// <summary>
        /// Calculates Lateral Acceleration with the current Forces. 
        /// Will drop to zero, if there is no change of the steerangle. 
        /// </summary>
        public double LateralAcceleration()
        {
            return (FyTotal / _mass) - (YawVelocity() * _forwardVelocity);
        }

        /// <summary>
        /// Calculates the lateral (side) velocity
        /// </summary>
        /// <returns></returns>
        public double LateralVelocity()
        {
            return PreviousLateralVelocity + _deltaT * LateralAcceleration();
        }
    }
}