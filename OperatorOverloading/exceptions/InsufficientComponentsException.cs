using System;
using System.Collections.Generic;
using System.Text;

namespace OperatorOverloading.exceptions
{
    class InsufficientComponentsException : ArgumentException
    {
        private const string Components = "A 3D Vector must contain exactly three components (x,y,z)";

        public InsufficientComponentsException() : base(Components)
        {
            Console.WriteLine(base.Message);
        }
        
        public InsufficientComponentsException(int length) : base(Components)
        {
            Console.WriteLine(base.Message);
            Console.WriteLine("Number of components actually passed: " + length);
        }
    }
}
