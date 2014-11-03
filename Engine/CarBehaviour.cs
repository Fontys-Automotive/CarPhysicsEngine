using System;
using System.Collections.Generic;
using CarPhysicsEngine;

namespace Engine
{
    public class CarBehaviour
    {
        /// <summary>
        /// Acceleration due to gravity
        /// </summary>
        private static double gravity;

        /// <summary>
        /// Forward Velocity for current iteration
        /// </summary>
        private readonly double forwardVelocity;

        /// <summary>
        /// Forward velocity for previous iteration
        /// </summary>
        private double previousForwardVelocity;

        /// <summary>
        /// Lateral velocity for current iteration
        /// </summary>
        private readonly double lateralVelocity;

        /// <summary>
        /// Lateral velocity for previous iteration
        /// </summary>
        private double previousLateralVelocity;

        /// <summary>
        /// Time step for current interation (for use with integration)
        /// </summary>
        private DateTime currentTime;

        /// <summary>
        /// Time step for previous iteration (for use with integration)
        /// </summary>
        private DateTime previousTime;

        /// <summary>
        /// Tyre force for previous iteration
        /// </summary>
        private double previousFyTotal;
        
        /// <summary>
        /// Torque (moment) for previous iteration
        /// </summary>
        private double previousMzTotal;

        /// <summary>
        /// Yaw velocity for previous iteration
        /// </summary>
        private double previousYawVelocity;

        /// <summary>
        /// Steer angle in radians. Input from steering wheel
        /// </summary>
        private double steerAngleRadians;

        private readonly Forces forces;
        private readonly Movement movement;
        private readonly Tyre tyre;

        /// <param name="steerAngleRadians">Steering wheel angle in radians</param>
        public CarBehaviour(double steerAngleRadians)
        {
            this.steerAngleRadians = steerAngleRadians;

            // Mass of the car
            const int mass = 1150;

            // Gravity (constant)
            gravity = 9.81f;

            // Wheelbase (distance between the centres of front and real wheels)
            const float length = 2.66f;

            // Length from front wheel to centre of gravity
            const float a = 1.06f;

            // Length from rear wheel to centre of gravity
            const float b = length - a;

            // Moment of intertia
            const int I = 1850;

            // Nominal load
            const double fz0 = 8000;

            // Forward velocity in m/s for 80km/h
            forwardVelocity = 80 / 3.6;

            // !TODO: Why is previous forward velocity initialized to the current forward velocity?
            previousForwardVelocity = forwardVelocity;

            currentTime = DateTime.Now;

            // Initialized to a small number greater than zero for first iteration
            double yawVelocityRadians = lateralVelocity = 0.0000001;

            // Initialized to zero because values are unknown at first iteration
            previousFyTotal = previousMzTotal = previousYawVelocity = previousLateralVelocity = 0;

            / /Object creation initialization

            tyre = new Tyre(mass, gravity, length, steerAngleRadians, yawVelocityRadians, lateralVelocity, a, fz0);
            forces = new Forces(tyre.tyreForceFront(), tyre.tyreForceRear(), a, b);
            movement = new Movement(forces.FyTotal(), forces.MzMoment(), I, mass, previousFyTotal, previousMzTotal, dt);
        }

        /// <summary>
        /// Calculate time step in seconds
        /// </summary>
        private double dt
        {
            get { return currentTime.Subtract(previousTime).TotalSeconds; }
        }

        /// <summary>
        /// This method is executed when the frame is updated
        /// </summary>
        public void Run()
        {
            // Check if this is the first iteration.
            // If yes, initialize both previous and current time to DateTime.Now
            // If no, update the value of previous time to current time.
            if (forwardVelocity == 0)
            {
                previousTime = currentTime = DateTime.Now;
            }
            else
            {
                previousTime = currentTime;
                currentTime = DateTime.Now;
            }

            // Update time in movement to ensure it always has the latest values
            movement.dt = dt;

            tyre.YawVelocity = movement.yawVelocity();
            tyre.LateralVelocity = movement.lateralVelocity();
            //tyre.SteerAngle = Wheel Axis Input in radians

            forces.Fy1 = tyre.tyreForceFront();
            forces.Fy2 = tyre.tyreForceRear();

            movement.CurrentFyTotal = forces.FyTotal();
            movement.CurrentMzTotal = forces.MzMoment();

            // Save the current values for future iterations (needed for integration)
            previousFyTotal = movement.CurrentFyTotal;
            previousMzTotal = movement.CurrentMzTotal;


            var position = new Position(forwardVelocity, previousForwardVelocity, yawVelocity(), previousYawVelocity,
                lateralVelocity, previousLateralVelocity, dt);

            //Save the current values for future iterations (needed for integration)
            previousForwardVelocity = position.CurrentForwardVelocity;
            previousLateralVelocity = position.CurrentLateralVelocity;
            previousYawVelocity = position.CurrentYawVelocity;

        }

        /// <summary>
        /// Calculate the acceleration for the car
        /// </summary>
        /// <returns>Acceleration</returns>
        public double acceleration()
        {
            var n1 = movement.accelerationY() + (movement.yawVelocity() * forwardVelocity);
            
            return n1 / gravity;
        }

        /// <summary>
        /// Calculate the yaw velocity
        /// </summary>
        /// <returns>Yaw Velocity</returns>
        public double yawVelocity()
        {
            return movement.yawVelocity() * (180 / Math.PI);
        }

        /// <summary>
        /// Calculate the steer angle in degrees
        /// </summary>
        /// <returns>Steer angle in degrees</returns>
        public double steerAngleDegrees()
        {
            var n1 = Math.Atan(movement.lateralVelocity() / forwardVelocity);
            return n1 * (180 / Math.PI);
        }
    }
}