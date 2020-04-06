using System;

namespace OperatorOverloading.exceptions
{
    [Serializable]
    class InvalidOperatorException : Exception
    {
        private new static readonly string Message = "Wrong operator: ";


        public InvalidOperatorException(string str) : base(Message)
        {
            Console.WriteLine(base.Message + str);
        }
    }
}
