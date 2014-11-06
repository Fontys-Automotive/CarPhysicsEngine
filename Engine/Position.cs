using System;

namespace CarPhysicsEngine
{
    public class Position
    {
        private readonly double _deltaT;
        private readonly double _forwardVelocity;

        public Position(double forwardVelocity, double deltaT)
        {
            _forwardVelocity = forwardVelocity;
            _deltaT = deltaT;
        }

        public double LateralVelocity { get; set; }
        public double YawVelocity { get; set; }
        public double PreviousYawVelocity { get; set; }

        private double YawVelocityIntegral()
        {
            return (YawVelocity - PreviousYawVelocity) * _deltaT;
        }

        public double CarPositionX()
        {
            var n1 = _forwardVelocity * Math.Cos(YawVelocityIntegral());
            var n2 = LateralVelocity * Math.Sin(YawVelocityIntegral());
            var n3 = n1 - n2;

            return n3 * _deltaT;
        }

        public double CarPositionY()
        {
            var n1 = _forwardVelocity * Math.Sin(YawVelocityIntegral());
            var n2 = LateralVelocity * Math.Cos(YawVelocityIntegral());
            var n3 = n1 + n2;

            return n3 * _deltaT;
        }
    }
}