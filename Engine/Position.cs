using System;

namespace CarPhysicsEngine
{
    public class Position
    {
        public double YawAngle { get; set; }
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
        
        /// <summary>
        /// Calculates the new YawAngle by adding the yaw change after one time step
        /// </summary>
        /// <returns></returns>
        public void YawVelocityIntegral()
        {
             YawAngle+=YawVelocity * _deltaT;
        }

        /// <summary>
        /// Calculates the change in X coordinate. Added to the current X position in CarBehaviour.Run()
        /// </summary>
        /// <returns></returns>
        public double VehicleDisplacementX()
        {
           
            var n1 = _forwardVelocity * Math.Cos(YawAngle);
            var n2 = LateralVelocity * Math.Sin(YawAngle);
            var n3 = n1 - n2;

            return n3 * _deltaT;
        }
        /// <summary>
        /// Calculates the change in Y coordinate after one time step. Added to the current Y position in CarBehaviour.Run()
        /// </summary>
        /// <returns></returns>
        public double VehicleDisplacementY()
        {
            var n1 = _forwardVelocity * Math.Sin(YawAngle);
            var n2 = LateralVelocity * Math.Cos(YawAngle);
            var n3 = n1 + n2;

            return n3 * _deltaT;
        }
    }
}