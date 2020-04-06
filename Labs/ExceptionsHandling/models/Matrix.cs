using System;
using ExceptionsHandling.exceptions;

namespace ExceptionsHandling.models
{
    /// <summary>
    /// Represents a Matrix, a dwo-dimensional rectangular array.
    /// </summary>
    class Matrix
    {
        public int[,] Values { get; private set; }
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public Matrix()
        {
        }
        /// <summary>
        /// Takes int[], where [0]th element represents rows, and [1]st element represents columns, and initializes Values property
        /// </summary>
        /// <param name="length">int[0] = rows,int [1] = columns</param>
        public Matrix(int[] length)
        {
            Values = new int[length[0], length[1]];
            Rows = Values.GetLength(0);
            Columns = Values.GetLength(1);
        }
        /// <summary>
        /// Takes 2-dimensional array values and initializes Values property
        /// </summary>
        /// <param name="values">values of a new Matrix</param>
        public Matrix(int[,] values)
        {
            Values = values;
            Rows = Values.GetLength(0);
            Columns = Values.GetLength(1);
        }

        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }

        /// <summary>
        /// Initializes a 1-dimensional Values property specifically for the result of multiplication
        /// </summary>
        /// <param name="length">Length of columns in the resulting 1-dimensional array</param>
        public Matrix(int length)
        {
            Values = new int[length,1];
        }

        /// <summary>
        /// Returns string representation of a Matrix values, rows separated by \n, columns separated by ", "
        /// </summary>
        /// <returns>string representation of the matrix </returns>
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < Rows; i++)
            {
                str += "[ ";
                for (int j = 0; j < Columns; j++)
                {
                    str += Values[i, j] + ", ";
                    if (j == Columns - 1)
                    {
                        str += "]";
                    }
                }

                if (i < Rows - 1)
                {
                    str += "\n";
                }
            }

            return str;
        }

        /// <summary>
        /// Sets all values of the Matrix to default 0
        /// </summary>
        public void ClearValues()
        {
            Array.Clear(Values, 0, Values.Length);
        }

        /// <summary>
        /// Returns a new matrix with pre-set dimensions and default values (0)
        /// </summary>
        /// <param name="dimensions"></param>
        /// <returns></returns>
        public Matrix GetEmpty()
        {
            Array.Clear(Values, 0, Values.Length);
            return this;
        }

        public static Matrix operator+ (Matrix a, Matrix b)
        {
            Matrix result;
            try
            {
                ValidateMatricesSize(a,b,"+");
                result = new Matrix(new int[] { a.Rows, a.Columns });
                for (int i = 0; i < a.Rows; i++)
                {
                    for (int j = 0; j < a.Columns; j++)
                    {
                        result.Values[i, j] = a.Values[i, j] + b.Values[i, j];
                    }
                }
            }
            catch (InvalidMatrixSizeException)
            {
                return null;
            }
            return result;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            Matrix result;
            try
            {
                ValidateMatricesSize(a, b, "-");
                result = new Matrix(new int[] { a.Rows, a.Columns });
                for (int i = 0; i < a.Rows; i++)
                {
                    for (int j = 0; j < a.Columns; j++)
                    {
                        result.Values[i, j] = a.Values[i, j] - b.Values[i, j];
                    }
                }
            }
            catch (InvalidMatrixSizeException)
            {
                return null;
            }
            return result;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            Matrix result;
            try
            {
                ValidateMatricesSize(a,b,"*");
                result = new Matrix(new int[] { a.Rows, b.Columns });
                for (int i = 0; i < result.Rows; i++)
                {
                    for (int j = 0; j < result.Columns; j++)
                    {
                        result.Values[i, j] = 0;
                        for (int k = 0; k < a.Columns; k++) // OR k<b.GetLength(0)
                            result.Values[i, j] = result.Values[i, j] + a.Values[i, k] * b.Values[k, j];
                    }
                }
            }
            catch (InvalidMatrixSizeException)
            {
                return null;
            }
            
            return result;
        }

        private static void ValidateMatricesSize(Matrix a, Matrix b, string operationName)
        {
            if (operationName == "*" && a.Columns != b.Rows)
            {
                throw new InvalidMatrixSizeException(new int[] { a.Rows, a.Columns }, new int[] { b.Rows, b.Columns }, operationName);
            }
            else if (operationName == "+" || operationName == "-")
            {
                if (a.Rows != b.Rows || a.Columns != b.Columns)
                    throw new InvalidMatrixSizeException(new int[] { a.Rows, b.Columns }, new int[] { b.Rows, b.Columns }, operationName);
            }
        }
    }
}
