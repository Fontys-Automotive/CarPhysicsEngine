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

        public double YawVelocity()
        {
            return PreviousYawVelocity + _deltaT * (MzTotal / _inertiaMoment);
        }

        /// <summary>
        /// Lateral Acceleration
        /// </summary>
        public double LateralAcceleration()
        {
            return (FyTotal / _mass) - (YawVelocity() * _forwardVelocity);
        }

        public double LateralVelocity()
        {
            return PreviousLateralVelocity + _deltaT * LateralAcceleration();
        }
    }
}