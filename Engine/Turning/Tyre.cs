using System;

namespace CarPhysicsEngine.Turning
{
    public class Tyre
    {
        public double ForwardVelocity { private get; set; }

        public double SteerAngle { private get; set; }
        public double YawVelocity { private get; set; }
        public double LateralVelocity { private get; set; }

        /// <summary>
        /// Calculates the force produced by the front wheel, given the alpha and the
        /// stiffness constant(look at the CarBehaviour constructor) for the tyre.
        /// </summary>
        /// <returns></returns>
        public double TyreForceFront()
        {
            // return AlphaFront() * Setup.Cy1;

            var nonlinearAlphaFront = AlphaFront();

            return (Setup.D *
                   Math.Sin(Setup.C *
                            Math.Atan(Setup.B * nonlinearAlphaFront - Setup.E *
                                      (Setup.B * nonlinearAlphaFront - 
                                      Math.Atan(Setup.B * nonlinearAlphaFront)))));
            
        }

        /// <summary>
        /// Calculates the force produced by the rear wheel,given the alpha and the 
        /// stiffness constant(look at the CarBehaviour constructor) for the tyre.
        /// </summary>
        /// <returns></returns>
        public double TyreForceRear()
        {
            var nonlinearAlphaRear = AlphaRear();
            return (Setup.D *
                   Math.Sin(Setup.C *
                            Math.Atan(Setup.B * nonlinearAlphaRear - Setup.E *
                                      (Setup.B * nonlinearAlphaRear -
                                      Math.Atan(Setup.B * nonlinearAlphaRear)))));
            //return AlphaRear() * Setup.Cy2;
            
        }

        /// <summary>
        /// Calculates the alpha of the front wheel angle in radians.
        /// </summary>
        /// <returns></returns>
        private double AlphaFront()
        {
            var n1 = (YawVelocity * Setup.LengthFront + LateralVelocity) / ForwardVelocity;

            return (SteerAngle - n1);
        }

        /// <summary>
        /// Calculates the alpha of the rear wheel angle in radians.
        /// </summary>
        /// <returns></returns>
        private double AlphaRear()
        {
            // Negating to ensure front and rear forces are being applied in the same direction
            var degrees = -(LateralVelocity - YawVelocity * Setup.LengthRear) / ForwardVelocity;
            return degrees;
        }
    }
}