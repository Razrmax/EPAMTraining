using System;

namespace ExceptionsHandling.exceptions
{
    /// <summary>
    /// The exception is thrown when user has entered an invalid value into the element of the existing Matrix.
    /// </summary>
    [Serializable]

    class InvalidMatrixElementValueException : FormatException
    {
        private static readonly string DefaultMessage = "Invalid value has been entered.";
        public string Value { get; }
        public string RequiredValueType { get; }

        public InvalidMatrixElementValueException() : base(DefaultMessage)
        {
        }

        public InvalidMatrixElementValueException(string message) : base(message)
        {
        }

        public InvalidMatrixElementValueException(string value, string requiredValueType) : base(DefaultMessage + "\n" + value + " is not of type " + requiredValueType)
        {
            this.Value = value;
            this.RequiredValueType = requiredValueType;
        }
    }
}
