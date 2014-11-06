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

        public double FyFront { get; set; }
        public double FyRear { get; set; }

        public double FyTotal()
        {
            return FyFront + FyRear;
        }

        public double MzMoment()
        {
            return (FyFront * _lengthFront) - (FyRear * _lengthRear);
        }
    }
}