using System.Collections.Generic;

namespace CarPhysicsEngine
{
    public class Setup
    {
        public readonly double Cw = 0.3; // C2-waarde [-]
        public readonly double Rho = 1.29; // Air Density [kg/m^3]
        public readonly double A = 2.25; // Frontal Area [m^2]
        public readonly double M = 950; // Vehicle Mass [kg]
        public readonly double G = 9.81; // Acceleration due to Gravity [m/s^2]
        public readonly double Fr = 0.014; // Rolling Resistance Coefficient [-]
        public readonly double MuMax = 1.05; // Maximum Friction Coefficient [-]
        public readonly double R = 0.3; // Tire Radius [m]
        public readonly double J1 = 1.2; // Traagheid ververbrandingsmotor [kgm^2]
        public readonly double J2 = 5.4; // Traagheid wielen en aandrijving [kgm^2]
        public readonly double SimulationTime = 1180; // [s]

        public readonly Dictionary<double, double> GearRatio = new Dictionary<double, double>()
        {
            {1, 12},
            {2, 7.5},
            {3, 5.5},
            {4, 4.5},
            {5, 3.75}
        };

        public readonly Dictionary<double, double> SwitchingBehaviour = new Dictionary<double, double>()
        {
            {1, 0},
            {2, 4.17},
            {3, 8.89},
            {4, 13.89},
            {5, 19.44}
        };

        public readonly Dictionary<double, double> EngineTorque = new Dictionary<double, double>()
        {
            {0, 50},
            {1000, 90},
            {2000, 90},
            {3000, 95},
            {4000, 100},
            {5000, 90},
            {6000, 85},
            {6500, 80},
            {7000, 0}
        };
    }
}