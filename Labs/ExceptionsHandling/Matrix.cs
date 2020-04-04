using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionsHandling
{
    class Matrix
    {
        public double[,] Values { get; private set; }
        public int Length { get; private set; }

        public Matrix(double[,] values)
        {
            Values = values;
            Length = values.Length;
        }

        protected void Generate(int x, int y)
        {
            Values = new double [x,y];
            Length = Values.Length;

            Random rand = new Random();
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    Values[i, j] = rand.NextDouble() * 100;
                }
            }
        }

        protected void SetValues(double [,] values)
        {
            Values = values;
            Length = Values.Length;
        }

    }
}
