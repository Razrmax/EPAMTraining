using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionsLab.exceptions
{
    class WrongArgumentException : FormatException
    {
        private static readonly string _message = "Wrong argument: ";
        public WrongArgumentException(string arg) : base(_message + arg)
        {
            Console.WriteLine(_message + arg);
        }
    }
}
