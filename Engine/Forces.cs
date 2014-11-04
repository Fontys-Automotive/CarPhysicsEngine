namespace CarPhysicsEngine
{
	public class Forces
	{
		private double a, b;
		
		public double TyreForceFront { get; set; } //Front wheel force
		public double TyreForceRear { get; set; } // Rear wheel force
		
		public Forces (double tyreForceFront, double tyreForceRear, double a, double b)
		{
			TyreForceFront = tyreForceFront;
			TyreForceRear = tyreForceRear;
			this.a = a;
			this.b = b;
			
		}

		public double FyTotal()
		{
			return TyreForceFront + TyreForceRear;
		}

		public double MzMoment()
		{
			var n1 = TyreForceFront * a;
			var n2 = TyreForceRear * b;
			return n1 - n2;
		}
	}
}