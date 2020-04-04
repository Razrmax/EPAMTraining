using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionsHandling
{
    class Calculator
    {
        public Matrix Result { get; set; }
        public Matrix MatrixA { get; set; }
        public Matrix MatrixB { get; set; }

        public Calculator(Matrix matrixA, Matrix matrixB)
        {
            MatrixA = matrixA;
            MatrixB = matrixB;
        }

        protected bool Multiply()
        {
            for (int i = 0; i < MatrixA.Length; i++)
            {
                for (int j = 0; j < MatrixA.Length; j++)
                {
                    try
                    {
                        Result.Values[i, j] = MatrixA.Values[i, j] * MatrixB.Values[i, j];
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        protected bool Add()
        {
            for (int i = 0; i < MatrixA.Length; i++)
            {
                for (int j = 0; j < MatrixA.Length; j++)
                {
                    try
                    {
                        Result.Values[i, j] = MatrixA.Values[i, j] + MatrixB.Values[i, j];
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        protected bool Substract()
        {
            for (int i = 0; i < MatrixA.Length; i++)
            {
                for (int j = 0; j < MatrixA.Length; j++)
                {
                    try
                    {
                        Result.Values[i, j] = MatrixA.Values[i, j] - MatrixB.Values[i, j];
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        protected Matrix GetClear()
        {
            Array.Clear(Result.Values, 0, Result.Length);
            return Result;
        }
    }
}
