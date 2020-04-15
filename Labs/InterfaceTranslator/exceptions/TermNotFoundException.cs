using System;

namespace InterfaceTranslator.exceptions
{
    class TermNotFoundException : Exception
    {
        private string term;
        private static readonly string message = "Term not found: ";

        public TermNotFoundException(string term) : base(message: message + term)
        {
            this.term = term;
            Console.WriteLine(base.Message);
        }
    }
}
