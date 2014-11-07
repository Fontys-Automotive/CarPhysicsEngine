using System;

namespace CarPhysicsEngine
{
    internal class MainClass
    {
        private static readonly CarBehaviour CarBehaviour = new CarBehaviour();

        public static void Main(string[] args)
        {
            var debugFlag = true;

            while (true)
            {
                CarBehaviour.Run();

                if (debugFlag)
                    Debug();
                else
                    Console.ReadLine();
            }
        }

        private static void Debug()
        {
            Console.Write("\n\n\n\nEnter new steer angle in degrees. [Blank for 0]: ");
            var angle = Console.ReadLine();

            if (angle.Equals(""))
                CarBehaviour.YawAngle = 0;
            else
                CarBehaviour.YawAngle = Convert.ToDouble(angle) * Math.PI / 180;

            Console.WriteLine("\nTimestamp: " + DateTime.Now);

            Console.WriteLine("\n========== SCREEN ==========");
            Console.WriteLine("Steer Angle (rad): " + CarBehaviour.YawAngle);
            Console.WriteLine("X:                 " + CarBehaviour.XCoordinate);
            Console.WriteLine("Y:                 " + CarBehaviour.YCoordinate);

            Console.WriteLine("\n========== FORCES ==========");
            Console.WriteLine("Front Wheel:       " + CarBehaviour.Tyre.TyreForceFront());
            Console.WriteLine("Rear Wheel:        " + CarBehaviour.Tyre.TyreForceRear());
            Console.WriteLine("Fy Total:          " + CarBehaviour.Forces.FyTotal());
            Console.WriteLine("Mz Total:          " + CarBehaviour.Forces.MzMoment());

            Console.WriteLine("\n========= MOVEMENT =========");
            Console.WriteLine("Forward Velocity:  " + CarBehaviour.ForwardVelocity);
            Console.WriteLine("Yaw Velocity:      " + CarBehaviour.Movement.YawVelocity());
            Console.WriteLine("Lateral Velocity:  " + CarBehaviour.Movement.LateralVelocity());
            Console.WriteLine("Lateral Acc.:      " + CarBehaviour.Movement.LateralAcceleration());

            Console.WriteLine("\n========== VEHICLE =========");
            Console.WriteLine("Displacement X:    " + CarBehaviour.Position.VehicleDisplacementX());
            Console.WriteLine("Displacement Y:    " + CarBehaviour.Position.VehicleDisplacementY());
        }
    }
}