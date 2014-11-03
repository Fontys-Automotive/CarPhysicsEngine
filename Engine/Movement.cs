using System;

namespace Engine
{
	public class Movement
	{
        /// <summary>
        /// Movement of Inertia
        /// </summary>
	    private readonly double I;

        /// <summary>
        /// Mass of vehicle
        /// </summary>
	    private readonly double mass;

        /// <summary>
        /// Current total force of wheels
        /// </summary>
		public double CurrentFyTotal{ get; set; }

        /// <summary>
        /// Current total torque (moment)
        /// </summary>
		public double CurrentMzTotal{ get; set; }

        /// <summary>
        /// Force on wheels as of previous iteration
        /// </summary>
		public double PreviousFyTotal{ get; set; }

        /// <summary>
        /// Torque as of previous iteration
        /// </summary>
		public double PreviousMzTotal{ get; set; }

        /// <summary>
        /// Time step 
        /// </summary>
	    public double dt { get; set; }
		
        public Movement (double currentFyTotal, double currentMzTotal, double I, double mass, double previousFyTotal, double previousMzTotal, double dt)
		{
			PreviousMzTotal = previousMzTotal;
			PreviousFyTotal = previousFyTotal;
		    CurrentMzTotal = currentMzTotal;
			CurrentFyTotal = currentFyTotal;
			this.I = I;
			this.mass = mass;
		}

        /// <summary>
        /// Calculate the yawVelocity
        /// </summary>
		public double yawVelocity()
		{
		    double dx = (CurrentMzTotal/I) - (PreviousMzTotal/I);
		    return dx / dt;
		}

        /// <summary>
        /// Calculate accelerationY.
        /// </summary>
	    public double accelerationY()
		{
	        return (CurrentFyTotal / mass) - (yawVelocity() * lateralVelocity());
		}

        /// <summary>
        /// Calculate acceleration from last iteration. It is used to calculate the lateral velocity.
        /// </summary>
        public double previousAccelerationY()
        {
            return (PreviousFyTotal / mass) - (yawVelocity() * lateralVelocity());
        }
		
        /// <summary>
        /// Calculate the lateral velocity
        /// </summary>
		public double lateralVelocity()
		{
		    double dx = accelerationY() - previousAccelerationY();

		    return dx/dt;
        }
	}
}