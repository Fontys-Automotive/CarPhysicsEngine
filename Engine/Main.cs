using System;

namespace CarPhysicsEngine
{
	class MainClass
	{
		public static void Main (string[] args)
		{
            while(true)
            {
                CarBehaviour carBehaviour = new CarBehaviour();

                carBehaviour.Run();

                Console.ReadLine();
            }
		}
	}
}
