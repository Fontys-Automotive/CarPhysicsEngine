namespace CarPhysicsEngine
{
    public class Forces
    {
        private readonly double _lengthFront;
        private readonly double _lengthRear;

        public Forces(double lengthFront, double lengthRear)
        {
            _lengthFront = lengthFront;
            _lengthRear = lengthRear;
        }

        public double TyreForceFront { get; set; }
        public double TyreForceRear { get; set; }

        /// <summary>
        /// Calculates the total Force of both wheels
        /// </summary>
        /// <returns></returns>
        public double FyTotal()
        {
            return TyreForceFront + TyreForceRear;
        }

        /// <summary>
        /// Calculates the Moment Torque. Returns 0, if there is no steering (no change of forces)
        /// </summary>
        /// <returns></returns>
        public double MzMoment()
        {
            return (TyreForceFront * _lengthFront) - (TyreForceRear * _lengthRear);
        }
    }
}