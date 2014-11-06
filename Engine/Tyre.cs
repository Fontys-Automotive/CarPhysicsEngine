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

        public double SteerAngle { get; set; }
        public double YawVelocity { get; set; }
        public double LateralVelocity { get; set; }

        public double TyreForceFront()
        {
            return AlphaFront() * _cy1;
        }

        public double TyreForceRear()
        {
            return AlphaRear() * _cy2;
        }

        private double AlphaFront()
        {
            var n1 = (YawVelocity * _lengthFront + LateralVelocity) / _forwardVelocity;

            return SteerAngle - n1;
           // return 0.019;
        }

        private double AlphaRear()
        {
            //TODO
            return   -((LateralVelocity - YawVelocity * _lengthRear) / _forwardVelocity);
            //return 0.013;
        }
    }
}