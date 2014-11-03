using System;
using System.Collections.Generic;
using CarPhysicsEngine;

namespace Engine
{
    public class CarBehaviour
    {
        private static double gravity;
        private readonly Forces forces;
        private readonly double forwardVelocity; //forward velocity
        private readonly double lateralVelocity;
        private readonly Movement movement; //?
        private readonly Tyre tyre;
        private DateTime currentTime;
        private double previousForwardVelocity;
        private double previousFyTotal;
        private double previousLateralVelocity;
        private double previousMzTotal;
        private DateTime previousTime;
        private double previousYawVelocity;
        private double steerAngleRadians;

        public CarBehaviour(double steerAngleRadians)
        {
            const int mass = 1150;
            gravity = 9.81f;
            const float length = 2.66f;
            const float a = 1.06f;
            const float b = length - a;
            const int I = 1850;
            const double fz0 = 8000;
            forwardVelocity = 80/3.6;
            double yawVelocityRadians = lateralVelocity = 0.0000001;
            currentTime = DateTime.Now;
            this.steerAngleRadians = steerAngleRadians;
            previousFyTotal = 0;
            previousMzTotal = 0;
            previousYawVelocity = 0;
            previousForwardVelocity = forwardVelocity;
            previousLateralVelocity = 0;

            //Object creation initialization

            tyre = new Tyre(mass, gravity, length, steerAngleRadians, yawVelocityRadians, lateralVelocity, a, fz0);
            forces = new Forces(tyre.tyreForceFront(), tyre.tyreForceRear(), a, b);
            movement = new Movement(forces.FyTotal(), forces.MzMoment(), I, mass, previousFyTotal, previousMzTotal, dt);
        }

        /// <summary>
        ///     Calculate time step in seconds
        /// </summary>
        private double dt
        {
            get { return currentTime.Subtract(previousTime).TotalSeconds; }
        }

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

        public double acceleration()
        {
            double n1 = movement.accelerationY() + (movement.yawVelocity()*forwardVelocity);
            double n2 = n1/gravity;

            return n2;
        }

        public double yawVelocity()
        {
            return movement.yawVelocity()*(180/Math.PI);
        }

        public double steerAngleDegrees()
        {
            double n1 = Math.Atan(movement.lateralVelocity()/forwardVelocity);
            double n2 = n1*(180/Math.PI);

            return n2;
        }

    }
}