using System;

namespace CarPhysicsEngine
{
	class MainClass
	{
		public static void Main (string[] args)
		{
            while(true)
            {
                new CarBehaviour().Run();

                // Wait for user input before continuing execution
                Console.ReadLine();
            }
		}
	}
}
