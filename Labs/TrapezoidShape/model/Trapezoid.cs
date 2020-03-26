using System;

namespace TrapezoidShape.model
{
    /// <summary>
    /// Trapezoid shape class, stores 
    /// </summary>
    class Trapezoid  
    {
        public int[] Sides { get; }
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
