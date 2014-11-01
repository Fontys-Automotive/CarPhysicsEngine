using System;

namespace Engine
{
	public class Forces
	{
		private double a, b;
		
		public double Fy1 { get; set; } //Front wheel force
		public double Fy2 { get; set; } // Rear wheel force
		
		public Forces (double Fy1, double Fy2, double a, double b)
		{
			this.Fy1 = Fy1;
			this.Fy2 = Fy2;
			this.a = a;
			this.b = b;
			
		}

		public double FyTotal()
		{
			return Fy1 + Fy2;
		}

		public double MzMoment()
		{
			double n1 = Fy1 * a;
			double n2 = Fy2 * b;
			return n1 - n2;
		}
	}
}