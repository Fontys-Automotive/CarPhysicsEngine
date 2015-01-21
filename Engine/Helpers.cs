namespace CarPhysicsEngine
{
    public static class Helpers
    {
        /// <summary>
        ///     MATLAB Saturation Dynamic Function
        ///     
        ///     Ensures input is within upper and lower bounds
        /// </summary>
        /// <param name="lowerBoundary">Minimum possible value</param>
        /// <param name="upperBoundary">Maximum possible value</param>
        /// <param name="input">Input to normalize</param>
        /// <returns>Normalized Input</returns>
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
