using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarPhysicsEngine
{
    public static class Helpers
    {
        public static double SaturationDynamic(double lowerBoundary, double upperBoundary, double input)
        {
            if (input > upperBoundary)
                return upperBoundary;

            if (input < lowerBoundary)
                return lowerBoundary;
            
            return input;
        }
    }
}
