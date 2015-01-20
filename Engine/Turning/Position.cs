using System;

namespace CarPhysicsEngine.Turning
{
    public class Position
    {
        public double YawAngle { private get; set; }
        public double ForwardVelocity { private get; set; }

        public double LateralVelocity { private get; set; }
        public double YawVelocity { private get; set; }
        public double DeltaT { private get; set; }
        
        /// <summary>
        /// Calculates the new YawAngle by adding the yaw change after one time step
        /// </summary>
        /// <returns></returns>
        public void YawVelocityIntegral()
        {
             YawAngle+=YawVelocity * DeltaT;
        }

        /// <summary>
        /// Calculates the change in X coordinate. Added to the current X position in CarBehaviour.Run()
        /// </summary>
        /// <returns></returns>
        public double VehicleDisplacementX()
        {
           
            var n1 = ForwardVelocity * Math.Cos(YawAngle);
            var n2 = LateralVelocity * Math.Sin(YawAngle);
            var n3 = n1 - n2;

            return n3 * DeltaT;
        }
        /// <summary>
        /// Calculates the change in Y coordinate after one time step. Added to the current Y position in CarBehaviour.Run()
        /// </summary>
        /// <returns></returns>
        public double VehicleDisplacementY()
        {
            var n1 = ForwardVelocity * Math.Sin(YawAngle);
            var n2 = LateralVelocity * Math.Cos(YawAngle);
            var n3 = n1 + n2;

            return n3 * DeltaT;
        }
    }
}