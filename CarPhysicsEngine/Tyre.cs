using System;

namespace Engine
{
	public class Tyre
	{
		private double mass;
		private double gravity;
		private double length;
		private double a, b;
		private double u; // forward velocity
		private double Fz0, Fz1, Fz2; //F0 - nominal load; F1 - front axle load; F2 - rear axle load
		private double C1, C2; // form factor
		private double D1, D2; //peak factor
		private double B1, B2; //stiffness factor
		private double K1, K2;
		private double mu1, mu2; //friction factor
		private double dFz1,dFz2;
		private double Cy1, Cy2; //Tyre stiffness 1-front, 2- rear
		private double eta = 0.03; //understeering factor. Max 0.04
		
		public double YawVelocity{ get; set; }
		public double LateralVelocity{ get; set; }
		public double SteerAngle{ get; set; }
		
		public Tyre (double mass, double gravity, double length, double steerAngle, double yawVelocity, double lateralVelocity, double a, double Fz0)
		{
			this.SteerAngle = steerAngle;
			this.YawVelocity = yawVelocity;
			this.LateralVelocity = lateralVelocity;
			this.a = a;
			this.b = b;
			this.C1 = this.C2 = 1.19;
			this.mass = mass;
			this.gravity = gravity;
			this.length = length;
			this.Fz0 = Fz0;
			this.Fz1 = (mass * gravity * b) / length;
			this.Fz2 = (mass * gravity * a) / length;
			this.dFz1 = (Fz1 - Fz0) / Fz0;
			this.dFz2 = (Fz2 - Fz0) / Fz0;
			this.mu1 = this.mu2 = 0.9;
			D1 = mu1 * (-0.145 * dFz1 + 0.99) * Fz1;
			D2 = mu2 * (-0.145 * dFz2 + 0.99) * Fz2;
			K1 = 14.95 * this.Fz0 * Math.Sin (2 * Math.Atan (Fz1 / 2.13 / this.Fz0));
			K2 = Fz2 * K1 / (Fz1 - eta * K1);
			B1 = K1 / C1 / D1;
			B2 = K2 / C2 / D2;
			Cy1 = B1 * C1 * D1;
			Cy2 = B2 * C2 * D2;
			
			
		}
		//TYRE FORCE
		public double tyreForceFront()
		{
			return alphaFront() * Cy1;
		}
		public double tyreForceRear()
		{
			return alphaRear() * Cy2;
		}

		// SLIP ANGLE
		private double alphaFront()
		{
			double n1 = (YawVelocity * a) + LateralVelocity;
			double n2 = n1 / u;
			double n3 = SteerAngle - n2;
			
			return n3;
		}
		
		private double alphaRear()
		{
			double n1 = (YawVelocity * b) + (LateralVelocity * (-1));
			double n2 = n1 / u;
			
			return n2;
		}
	}
}
