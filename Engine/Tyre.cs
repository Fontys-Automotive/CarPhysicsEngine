namespace CarPhysicsEngine
{
    public class Tyre
    {
        private readonly double _cy1;
        private readonly double _cy2;
        private readonly double _forwardVelocity;
        private readonly double _lengthFront;
        private readonly double _lengthRear;

        public Tyre(double lengthFront, double lengthRear, double forwardVelocity, double cy1, double cy2, double steerAngle)
        {
            _lengthRear = lengthRear;
            _lengthFront = lengthFront;
            _forwardVelocity = forwardVelocity;
            _cy1 = cy1;
            _cy2 = cy2;
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
            return AlphaFront() * _cy1;
        }

        /// <summary>
        /// Calculates the force produced by the rear wheel,given the alpha and the 
        /// stiffness constant(look at the CarBehaviour constructor) for the tyre.
        /// </summary>
        /// <returns></returns>
        public double TyreForceRear()
        {
            return AlphaRear() * _cy2;
        }

        /// <summary>
        /// Calculates the alpha of the front wheel angle.
        /// </summary>
        /// <returns></returns>
        private double AlphaFront()
        {
            var n1 = (YawVelocity * _lengthFront + LateralVelocity) / _forwardVelocity;

            return SteerAngle - n1;
        }

        /// <summary>
        /// Calculates the alpha of the rear wheel angle
        /// </summary>
        /// <returns></returns>
        private double AlphaRear()
        {
            // Negating to ensure front and rear forces are being applied in the same direction
            return -(LateralVelocity - YawVelocity * _lengthRear) / _forwardVelocity;
        }
    }
}