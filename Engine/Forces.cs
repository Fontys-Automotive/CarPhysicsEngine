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

        public double FyTotal()
        {
            return TyreForceFront + TyreForceRear;
        }

        public double MzMoment()
        {
            var result = (TyreForceFront * _lengthFront) - (TyreForceRear * _lengthRear);
            return result;
        }
    }
}