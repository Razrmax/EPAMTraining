namespace TrapezoidShape.model
{
    /// <summary>
    /// Trapezoid shape class, stores values of a trapezoid sides a,b,c,d, and height h as readonly properties
    /// Calculates area and perimeter
    /// </summary>
    //       ____b______
    //      /|          |\ 
    //    c/ |h         | \d
    //    /__|__a_______|__\
    class Trapezoid
    {
        public double ASide { get; }
        public double BSide { get; }
        public double CSide { get; }
        public double DSide { get; }
        public double Perimeter { get; }
        public double Area { get; }
        public double H { get; }

        /// <summary>
        /// 5 input values constructor. Gets a,b,c,d, and h, and calculates Perimeter and Area
        /// </summary>
        /// <param name="a">bottom base length</param>
        /// <param name="b">top base length</param>
        /// <param name="c">left lateral side</param>
        /// <param name="d">right lateral side</param>
        public Trapezoid(double a, double b, double c, double d, double h)
        {
            ASide = a;
            BSide = b;
            CSide = c;
            DSide = d;
            H = h;

            Area = CalcArea();
            Perimeter = CalcPerimeter();
        }
        /// <summary>
        /// Calculates area of a trapezoid: A = h * ((a + b) / 2).
        /// </summary>
        private double CalcArea()
        {
            return H * ((ASide + BSide) / 2);
        }
        /// <summary>
        /// Calculates perimeter of a trapezoid (a + b + c + d).
        /// </summary>
        private double CalcPerimeter()
        {
            return ASide + BSide + CSide + DSide;
        }
    }
}
