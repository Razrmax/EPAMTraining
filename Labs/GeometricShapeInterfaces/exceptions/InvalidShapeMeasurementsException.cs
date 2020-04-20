using System;

namespace GeometricShapeInterfaces.exceptions
{
    class InvalidShapeMeasurementsException : Exception
    {
        private static readonly string InvalidNumberOfSidesMessage = "Invalid number of sides";
        private static readonly string InvalidSideMeasurement = "Invalid side value";


        public InvalidShapeMeasurementsException(int expected, int actual) : base(InvalidNumberOfSidesMessage)
        {
            DisplayExpectedActual(Convert.ToString(expected), Convert.ToString(actual));
        }

        public InvalidShapeMeasurementsException(string expected, double actual) : base(InvalidSideMeasurement)
        {
            DisplayExpectedActual(expected, Convert.ToString(actual));
        }

        private static void DisplayExpectedActual(string expected, string actual)
        {
            Console.WriteLine("Expected: " + expected);
            Console.WriteLine("Actual: " + actual);
        }
    }
}
