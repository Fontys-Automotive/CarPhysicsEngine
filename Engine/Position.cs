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

        public double VehicleDisplacementX()
        {
            double n1 = _forwardVelocity * Math.Cos(YawVelocityIntegral());
            double n2 = LateralVelocity * Math.Sin(YawVelocityIntegral());
            double n3 = n1 - n2;

            return n3 * _deltaT;
        }

        public double VehicleDisplacementY()
        {
            double n1 = _forwardVelocity * Math.Sin(YawVelocityIntegral());
            double n2 = LateralVelocity * Math.Cos(YawVelocityIntegral());
            double n3 = n1 + n2;

            return n3 * _deltaT;
        }
    }
}