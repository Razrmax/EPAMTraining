using System;
using System.Collections.Generic;
using System.Text;

namespace TrapezoidShape.model
{
    class Trapezoid : ISidesCalculator
    {
        private int[] sides = new int[4];
        public int Perimeter { get; set; }
        public int Area { get; set; }

        public int CalcArea(int[] sides)
        {
            throw new NotImplementedException();
        }

        public int CalcPerimeter(int[] sides)
        {
            throw new NotImplementedException();
        }

        public bool isValidShape(int[] sides)
        {
            throw new NotImplementedException();
        }
    }
}
