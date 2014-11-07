using System;

namespace CarPhysicsEngine
{
    public class Position
    {
        private double YawAngle { get; set; }
        private readonly double _deltaT;
        private readonly double _forwardVelocity;

        public Position(double forwardVelocity, double deltaT, double yawAngle)
        {
            YawAngle = yawAngle;
            _forwardVelocity = forwardVelocity;
            _deltaT = deltaT;
        }

        public double LateralVelocity { private get; set; }
        public double YawVelocity { private get; set; }
        
        private double YawVelocityIntegral()
        {
            return YawAngle+=YawVelocity * _deltaT;
        }

        public double VehicleDisplacementX()
        {
            var u = _forwardVelocity * Math.Cos(YawAngle) - LateralVelocity * Math.Sin(YawAngle);
            var v = _forwardVelocity * Math.Sin(YawAngle) + LateralVelocity * Math.Cos(YawAngle);

            var m = (u - v) * _deltaT;

            var n1 = _forwardVelocity * Math.Cos(YawVelocityIntegral());
            var n2 = LateralVelocity * Math.Sin(YawVelocityIntegral());
            var n3 = n1 - n2;

            return n3 * _deltaT;
        }

        public double VehicleDisplacementY()
        {
            var n1 = _forwardVelocity * Math.Sin(YawVelocityIntegral());
            var n2 = LateralVelocity * Math.Cos(YawVelocityIntegral());
            var n3 = n1 + n2;

            return n3 * _deltaT;
        }
    }
}