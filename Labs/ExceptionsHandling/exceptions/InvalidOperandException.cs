using System;

namespace ExceptionsHandling.exceptions
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
            Console.WriteLine(DefaultMessage);
            Console.WriteLine("Expected: " + Expected);
            Console.WriteLine("Actual: " + Actual);
        }
        public InvalidOperandException(string str, int expected, int actual) : base(str)
        {
            Console.WriteLine(str);
            Actual = Convert.ToString(actual);
            Expected = Convert.ToString(expected);
            Console.WriteLine("Expected length: " + Expected);
            Console.WriteLine("Actual length: " + Actual);
        }
    }
}
