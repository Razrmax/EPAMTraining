using System;

namespace ExceptionsHandling.exceptions
{
    [Serializable]
    class InvalidOperatorException : Exception
    {
        private new static readonly string Message = "Invalid operator: ";
        public string Oper { get; }


        public InvalidOperatorException(string oper) : base(Message)
        {
            Oper = oper;
            Console.WriteLine(base.Message + Oper);
        }
    }
}
