using System;

namespace ExceptionsHandling.exceptions
{
    [Serializable]
    class InvalidOperatorException : Exception
    {
        private new static readonly string Message = "Wrong arithmetic operator: ";


        public InvalidOperatorException(string str) : base(Message)
        {
            Console.WriteLine(Message + str);
        }
    }
}
