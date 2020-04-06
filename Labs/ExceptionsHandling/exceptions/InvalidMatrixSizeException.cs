using System;

namespace ExceptionsHandling.exceptions
{
    /// <summary>
    /// Throws error when two passed matrices are of invalid sizes for specific arithmetic operations.
    /// </summary>
    [Serializable]
    class InvalidMatrixSizeException : Exception
    {
        private static readonly string DefaultMessage = "The size of matrices is incompatible with this type of operations";
        public int[] XDimensions { get; }
        public int[] YDimensions { get; }
        public string OperationName { get; }

        public InvalidMatrixSizeException() : base(DefaultMessage)
        {
        }
        public InvalidMatrixSizeException(string message) : base(message)
        {
            Console.WriteLine(message);
        }
        /// <summary>
        /// Throws exception when two matrices are of invalid size
        /// </summary>
        /// <param name="xDimensions"></param>
        /// <param name="yDimensions"></param>
        /// <param name="operationName"></param>
        public InvalidMatrixSizeException(int[] xDimensions, int[] yDimensions, string operationName) : base(DefaultMessage)
        {
            this.XDimensions = xDimensions;
            this.YDimensions = yDimensions;
            this.OperationName = operationName;
            Console.WriteLine(base.Message);
            Console.WriteLine("Operation: " + operationName);
            Console.WriteLine("Matrix A dimensions: {0} rows, {1} columns", xDimensions[0], xDimensions[1]);
            Console.WriteLine("Matrix B dimensions: {0} rows, {1} columns", yDimensions[0], yDimensions[1]);
        }
    }
}
