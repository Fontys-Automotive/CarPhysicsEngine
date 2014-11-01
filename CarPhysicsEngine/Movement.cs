using System;

namespace Engine
{
	public class Movement
	{
		private double time;
		private double I; //Moment of Inertia
		private double forwardVelocity;
		private double mass;
		public double FyTotal{ get; set; }
		public double MzTotal{ get; set; }
		public double PreviousFyTotal{ get; set; }
		public double PreviousMzTotal{ get; set; }
		private DateTime currentTime;
		private DateTime previousTime;
		
		public Movement (double FyTotal, double MzTotal, double I, double forwardVelocity, double mass, double previousFyTotal, double previousMzTotal, DateTime previousTime)
		{
			this.PreviousMzTotal = previousMzTotal;
			this.PreviousFyTotal = previousFyTotal;
			this.forwardVelocity = forwardVelocity;
			this.MzTotal = MzTotal;
			this.FyTotal = FyTotal;
			this.I = I;
			this.mass = mass;
			this.previousTime = previousTime;
			this.currentTime = DateTime.Now;
			
		}

		public double yawVelocity()
		{
			//Calculate Total mass of Inertia divided by moment of inertia
			double n1 = MzTotal / I;
			double n2 = PreviousMzTotal / I;
			double dm = n1 - n2;
			double dt = (currentTime - previousTime).Ticks;
			double result = dm / dt;
			return result;
		}

		public double accelerationY()
		{
			//TO CHECK if lateralVelocity is the value here
			double result = (this.FyTotal / mass) - (yawVelocity() * lateralVelocity());
			return result;
		}
		
		public double lateralVelocity()
		{
			double result = accelerationY() * time;
			return result;
		}
	}
}