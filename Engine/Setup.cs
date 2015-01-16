using System;
using System.Collections.Generic;

namespace CarPhysicsEngine
{
    public static class Setup
    {
        // Global
        public const double M = 1150; // Vehicle Mass [kg]
        public const double G = 9.81; // Acceleration due to Gravity [m/s^2]
        public const double DeltaT = 0.01; // Change in time [s]

        // Needed for Turning
        private const double LengthWheelbase = 2.66; // wheelbase length [m]
        public const double LengthFront = 1.06; // distance from front axle to centre [m]
        public const double LengthRear = LengthWheelbase - LengthFront; // distance from rear axle to centre [m]
        public const double InertiaMoment = 1850; // moment of inertia of vehicle on z-axis [kgm^2]
        private const double ETA = 0.03; // understeer factor. Plausible max value is 0.04
        private const double Fz0 = 8000; // Nominal load [N]
        private const double Fz1 = M * G * LengthRear / LengthWheelbase; // Axle load front [N]
        private const double Fz2 = M * G * LengthFront / LengthWheelbase; // Axle load read [N]
        private const double DFz1 = (Fz1 - Fz0) / Fz0;
        private const double DFz2 = (Fz2 - Fz0) / Fz0;
        private const double Mu1 = 0.09; // coefficient of friction front [-]
        private const double Mu2 = 0.09; // coefficient of friction rear [-]
        private const double D1 = Mu1 * (-0.145 * DFz1 + 0.99) * Fz1; // Peak-factor front [N]
        private const double D2 = Mu2 * (-0.145 * DFz2 + 0.99) * Fz2; // Peak-factor rear [N]
        private const double C1 = 1.19; // "vormfactor" front [-]
        private const double C2 = 1.19; // "vormfactor" rear [-]
        private static readonly double K1 = 14.95 * Fz0 * Math.Sin(2 * Math.Atan(Fz1 / 2.13 / Fz0));
        private static readonly double K2 = Fz2 * K1 / (Fz1 - ETA * K1);
        private static readonly double B1 = K1 / C1 / D1; // Stiffness factor front
        private static readonly double B2 = K2 / C2 / D2; // Stiffness factor rear
        public const double E1 = -1.003 - 0.537 * DFz1; // curvature factor front
        public const double E2 = -1.003 - 0.537 * DFz2; // curvature factor rear
        public static readonly double Cy1 = B1 * C1 * D1; // Tyre stiffness front [N/rad]
        public static readonly double Cy2 = B2 * C2 * D2; // Tyre stiffness rear [N/rad]

        // Needed for Acceleration
        public const double Cw = 0.3; // C2-waarde [-]
        public const double Rho = 1.29; // Air Density [kg/m^3]
        public const double A = 2.25; // Frontal Area [m^2]
        public const double Fr = 0.014; // Rolling Resistance Coefficient [-]
        public const double MuMax = 1.05; // Maximum Friction Coefficient [-]
        public const double R = 0.3; // Tire Radius [m]

        public struct EngineTorqueKey
        {
            private double rpm, throttlePercentage;

            public EngineTorqueKey(double rpm, double throttlePercentage)
            {
                this.rpm = rpm;
                this.throttlePercentage = throttlePercentage;
            }
        }

        public static readonly Dictionary<double, double> GearRatio = new Dictionary<double, double>()
        {
            {1, 12},
            {2, 7.5},
            {3, 5.5},
            {4, 4.5},
            {5, 3.75}
        };

        public static readonly Dictionary<double, double> SwitchingBehaviour = new Dictionary<double, double>()
        {
            {1, 0},
            {2, 4.17},
            {3, 8.89},
            {4, 13.89},
            {5, 19.44}
        };

        public static readonly Dictionary<EngineTorqueKey, double> EngineTorque = new Dictionary<EngineTorqueKey, double>()
        {
            // RPM => 1400
            { new EngineTorqueKey(1400, 0),  -18 },
            { new EngineTorqueKey(1400, 20),  22 },
            { new EngineTorqueKey(1400, 30),  25 },
            { new EngineTorqueKey(1400, 40),  28 },
            { new EngineTorqueKey(1400, 50),  37 },
            { new EngineTorqueKey(1400, 60),  47 },
            { new EngineTorqueKey(1400, 70),  56 },
            { new EngineTorqueKey(1400, 80),  65 },
            { new EngineTorqueKey(1400, 90),  75 },
            { new EngineTorqueKey(1400, 100), 84 },

            // RPM => 1900
            { new EngineTorqueKey(1900, 0),  -19.5 },
            { new EngineTorqueKey(1900, 20),  23 },
            { new EngineTorqueKey(1900, 30),  26 },
            { new EngineTorqueKey(1900, 40),  29 },
            { new EngineTorqueKey(1900, 50),  39 },
            { new EngineTorqueKey(1900, 60),  49 },
            { new EngineTorqueKey(1900, 70),  59 },
            { new EngineTorqueKey(1900, 80),  68 },
            { new EngineTorqueKey(1900, 90),  78 },
            { new EngineTorqueKey(1900, 100), 88 },

            // RPM => 2400
            { new EngineTorqueKey(2400, 0),  -21.5 },
            { new EngineTorqueKey(2400, 20),  11 },
            { new EngineTorqueKey(2400, 30),  22 },
            { new EngineTorqueKey(2400, 40),  32 },
            { new EngineTorqueKey(2400, 50),  43 },
            { new EngineTorqueKey(2400, 60),  54 },
            { new EngineTorqueKey(2400, 70),  65 },
            { new EngineTorqueKey(2400, 80),  75 },
            { new EngineTorqueKey(2400, 90),  86 },
            { new EngineTorqueKey(2400, 100), 97 },

            // RPM => 2900
            { new EngineTorqueKey(2900, 0),  -23.5 },
            { new EngineTorqueKey(2900, 20),  11 },
            { new EngineTorqueKey(2900, 30),  22 },
            { new EngineTorqueKey(2900, 40),  33 },
            { new EngineTorqueKey(2900, 50),  44 },
            { new EngineTorqueKey(2900, 60),  54 },
            { new EngineTorqueKey(2900, 70),  65 },
            { new EngineTorqueKey(2900, 80),  76 },
            { new EngineTorqueKey(2900, 90),  87 },
            { new EngineTorqueKey(2900, 100), 98 },

            // RPM => 3300
            { new EngineTorqueKey(3300, 0),  -25 },
            { new EngineTorqueKey(3300, 20),  11 },
            { new EngineTorqueKey(3300, 30),  22 },
            { new EngineTorqueKey(3300, 40),  33 },
            { new EngineTorqueKey(3300, 50),  44 },
            { new EngineTorqueKey(3300, 60),  56 },
            { new EngineTorqueKey(3300, 70),  67 },
            { new EngineTorqueKey(3300, 80),  78 },
            { new EngineTorqueKey(3300, 90),  89 },
            { new EngineTorqueKey(3300, 100), 100 },

            // RPM => 3800
            { new EngineTorqueKey(3800, 0),  -26.5 },
            { new EngineTorqueKey(3800, 20),  12 },
            { new EngineTorqueKey(3800, 30),  23 },
            { new EngineTorqueKey(3800, 40),  35 },
            { new EngineTorqueKey(3800, 50),  46 },
            { new EngineTorqueKey(3800, 60),  58 },
            { new EngineTorqueKey(3800, 70),  69 },
            { new EngineTorqueKey(3800, 80),  81 },
            { new EngineTorqueKey(3800, 90),  92 },
            { new EngineTorqueKey(3800, 100), 104 },

            // RPM => 4000
            { new EngineTorqueKey(4000, 0),  -27.5 },
            { new EngineTorqueKey(4000, 20),  11 },
            { new EngineTorqueKey(4000, 30),  23 },
            { new EngineTorqueKey(4000, 40),  34 },
            { new EngineTorqueKey(4000, 50),  45 },
            { new EngineTorqueKey(4000, 60),  57 },
            { new EngineTorqueKey(4000, 70),  68 },
            { new EngineTorqueKey(4000, 80),  79 },
            { new EngineTorqueKey(4000, 90),  91 },
            { new EngineTorqueKey(4000, 100), 102 },

            // RPM => 4200
            { new EngineTorqueKey(4200, 0),  -28 },
            { new EngineTorqueKey(4200, 20),  11 },
            { new EngineTorqueKey(4200, 30),  22 },
            { new EngineTorqueKey(4200, 40),  33 },
            { new EngineTorqueKey(4200, 50),  44 },
            { new EngineTorqueKey(4200, 60),  54 },
            { new EngineTorqueKey(4200, 70),  65 },
            { new EngineTorqueKey(4200, 80),  76 },
            { new EngineTorqueKey(4200, 90),  87 },
            { new EngineTorqueKey(4200, 100), 98 },

            // RPM => 4500
            { new EngineTorqueKey(4500, 0),  -29 },
            { new EngineTorqueKey(4500, 20),  10 },
            { new EngineTorqueKey(4500, 30),  20 },
            { new EngineTorqueKey(4500, 40),  31 },
            { new EngineTorqueKey(4500, 50),  41 },
            { new EngineTorqueKey(4500, 60),  51 },
            { new EngineTorqueKey(4500, 70),  61 },
            { new EngineTorqueKey(4500, 80),  72 },
            { new EngineTorqueKey(4500, 90),  82 },
            { new EngineTorqueKey(4500, 100), 92 },

            // RPM => 5000
            { new EngineTorqueKey(5000, 0),  -31 },
            { new EngineTorqueKey(5000, 20),  9 },
            { new EngineTorqueKey(5000, 30),  18 },
            { new EngineTorqueKey(5000, 40),  28 },
            { new EngineTorqueKey(5000, 50),  37 },
            { new EngineTorqueKey(5000, 60),  46 },
            { new EngineTorqueKey(5000, 70),  55 },
            { new EngineTorqueKey(5000, 80),  65 },
            { new EngineTorqueKey(5000, 90),  74 },
            { new EngineTorqueKey(5000, 100), 83 },

            // RPM => 5400
            { new EngineTorqueKey(5400, 0),  -32.5 },
            { new EngineTorqueKey(5400, 20),  9 },
            { new EngineTorqueKey(5400, 30),  17 },
            { new EngineTorqueKey(5400, 40),  26 },
            { new EngineTorqueKey(5400, 50),  34 },
            { new EngineTorqueKey(5400, 60),  43 },
            { new EngineTorqueKey(5400, 70),  51 },
            { new EngineTorqueKey(5400, 80),  60 },
            { new EngineTorqueKey(5400, 90),  68 },
            { new EngineTorqueKey(5400, 100), 77 },

            // RPM => 5800
            { new EngineTorqueKey(5800, 0),  -33.5 },
            { new EngineTorqueKey(5800, 20),  8 },
            { new EngineTorqueKey(5800, 30),  16 },
            { new EngineTorqueKey(5800, 40),  24 },
            { new EngineTorqueKey(5800, 50),  32 },
            { new EngineTorqueKey(5800, 60),  40 },
            { new EngineTorqueKey(5800, 70),  48 },
            { new EngineTorqueKey(5800, 80),  56 },
            { new EngineTorqueKey(5800, 90),  64 },
            { new EngineTorqueKey(5800, 100), 72 },

            // RPM => 6000
            { new EngineTorqueKey(6000, 0),  -34.5 },
            { new EngineTorqueKey(6000, 20),  8 },
            { new EngineTorqueKey(6000, 30),  16 },
            { new EngineTorqueKey(6000, 40),  23 },
            { new EngineTorqueKey(6000, 50),  31 },
            { new EngineTorqueKey(6000, 60),  39 },
            { new EngineTorqueKey(6000, 70),  47 },
            { new EngineTorqueKey(6000, 80),  54 },
            { new EngineTorqueKey(6000, 90),  62 },
            { new EngineTorqueKey(6000, 100), 70 },
        };
    }
}