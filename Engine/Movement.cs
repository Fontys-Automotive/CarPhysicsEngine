using System.Runtime.InteropServices;

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
            //var n1 = (MzTotal / _inertiaMoment) - (PreviousMzTotal / _inertiaMoment);
            //return n1 * _deltaT;
            return PreviousYawVelocity + _deltaT * ((MzTotal / _inertiaMoment)+ (MzTotal / _inertiaMoment) - (PreviousMzTotal / _inertiaMoment));
        }

        /// <summary>
        /// Lateral Acceleration
        /// </summary>
        public double AccelerationY()
        {
            return (FyTotal / _mass) - (YawVelocity() * _forwardVelocity);
        }

        private double PreviousAccelerationY()
        {
            return (PreviousFyTotal / _mass) - (PreviousYawVelocity * _forwardVelocity);
        }

        public double LateralVelocity()
        {
            //return (AccelerationY() - PreviousAccelerationY()) * _deltaT;

            return PreviousLateralVelocity + _deltaT * (AccelerationY() + (AccelerationY() - PreviousAccelerationY()));

        }
    }
}