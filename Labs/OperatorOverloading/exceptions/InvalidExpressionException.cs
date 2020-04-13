using System;

namespace OperatorOverloading.exceptions
{
    class InvalidExpressionException : Exception
    {
        private new static readonly string Message = "Not enough operands";
        public int Expected { get; }
        public int Actual { get; }

        public InvalidExpressionException() : base(Message)
        {
            Console.WriteLine(base.Message);
        }

        public InvalidExpressionException(string str) : base(str)
        {
            Console.WriteLine(base.Message);
        }

        public InvalidExpressionException(int expected, int actual) : base(Message)
        {
            Expected = expected;
            Actual = actual;
            Console.WriteLine(base.Message);
            Console.WriteLine("Expected: " + expected);
            Console.WriteLine("Actual: " + actual);
        }
    }
}
