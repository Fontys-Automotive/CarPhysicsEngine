namespace CarPhysicsEngine.Turning
{
    public class Tyre
    {
        private readonly double _forwardVelocity;

        public Tyre(double forwardVelocity, double steerAngle)
        {
            _forwardVelocity = forwardVelocity;
            SteerAngle = steerAngle;
        }

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
            return AlphaFront() * Setup.Cy1;
        }

        /// <summary>
        /// Calculates the force produced by the rear wheel,given the alpha and the 
        /// stiffness constant(look at the CarBehaviour constructor) for the tyre.
        /// </summary>
        /// <returns></returns>
        public double TyreForceRear()
        {
            return AlphaRear() * Setup.Cy2;
        }

        /// <summary>
        /// Calculates the alpha of the front wheel angle.
        /// </summary>
        /// <returns></returns>
        private double AlphaFront()
        {
            var n1 = (YawVelocity * Setup.LengthFront + LateralVelocity) / _forwardVelocity;

            return SteerAngle - n1;
        }

        /// <summary>
        /// Calculates the alpha of the rear wheel angle
        /// </summary>
        /// <returns></returns>
        private double AlphaRear()
        {
            // Negating to ensure front and rear forces are being applied in the same direction
            return -(LateralVelocity - YawVelocity * Setup.LengthRear) / _forwardVelocity;
        }
    }
}