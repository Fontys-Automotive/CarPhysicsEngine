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
        public double PreviousFyTotal { get; set; }
        public double MzTotal { get; set; }
        public double PreviousMzTotal { get; set; }
        public double PreviousLateralVelocity { get; set; }
        public double PreviousYawVelocity { get; set; }

        public double YawVelocity()
        {
            return PreviousYawVelocity + _deltaT * YawAcceleration();
        }

        public double LateralAcceleration()
        {
            return (FyTotal / _mass) - _forwardVelocity * PreviousLateralVelocity;
        }

        public double YawAcceleration()
        {
            return MzTotal / _inertiaMoment;
        }

        public double LateralVelocity()
        {
            return PreviousLateralVelocity + _deltaT * LateralAcceleration();
        }
    }
}