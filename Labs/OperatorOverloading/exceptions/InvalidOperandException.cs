using System;

namespace OperatorOverloading.exceptions
{
    class InvalidOperandException : FormatException
    {
        private static readonly string DefaultMessage = "Operand is invalid";
        public string Actual { get; }
        public string Expected { get; }

        public InvalidOperandException(string actual, string expected) : base(DefaultMessage)
        {
            Actual = actual;
            Expected = expected;
            Console.WriteLine(base.Message);
            Console.WriteLine("Expected: " + Expected);
            Console.WriteLine("Actual: " + Actual);
        }
        public InvalidOperandException(string message, int expected, int actual) : base(message)
        {
            Console.WriteLine(base.Message);
            Actual = Convert.ToString(actual);
            Expected = Convert.ToString(expected);
            Console.WriteLine("Expected length: " + Expected);
            Console.WriteLine("Actual length: " + Actual);
        }
    }
}
