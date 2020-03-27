using System;

namespace TrapezoidShape.model
{
    /// <summary>
    /// Trapezoid shape class, stores 
    /// </summary>
    class Trapezoid 
    {
        public double ASide { get; }
        public double BSide { get; }
        public double CSide { get; }
        public double DSide { get; }
        public double Perimeter { get; set;  }
        public double Area { get; set; }
        public double Height { get; }
        public string TrapezoidType { get; }

        /// <summary>
        /// 4 values constructor. Gets 4 valid values of a,b,c,d, calculates if it is a Right or Isosceles trapezoid, and calculates all parameters
        /// </summary>
        /// <param name="a">bottom base length</param>
        /// <param name="b">top base length</param>
        /// <param name="c">left lateral side</param>
        /// <param name="d">right lateral side</param>
        /// <param name="trapezoidType">trapezoid type, can be of two types: "Right" (left side perpendicular to bases), and "Isosceles" (both left and right sides of equal height)</param>
        public Trapezoid(double a, double b, double c, double d)
        {
            ASide = a;
            BSide = b;
            CSide = c;
            DSide = d;

            if (c == d)
            {
                TrapezoidType = "Isosceles";
                Triangle triangle = new Triangle(Math.Abs(a - b) / 2, c, true);
                Height = triangle.FindThirdSide();
            }
            else
            {
                TrapezoidType = "Right";
                Triangle triangle = new Triangle(Math.Abs(a - b), c, false);
                Height = triangle.FindThirdSide();
            }

            CalcArea();
            CalcPerimeter();
        }
        /// <summary>
        /// Calculates area of a trapezoid based on the formula: A = h * ((a + b) / 2).
        /// </summary>
        private void CalcArea()
        {
            Area = Height * ((ASide + BSide) / 2);
        }
        /// <summary>
        /// Calculates perimeter of a trapezoid (a + b + c + d).
        /// </summary>
        private void CalcPerimeter()
        {
            Perimeter = ASide + BSide + CSide + DSide;
        }

    }
}
