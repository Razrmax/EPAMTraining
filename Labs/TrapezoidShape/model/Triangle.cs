using System;

namespace TrapezoidShape.model
{
    class Triangle
    {
        public double ASide { get; }
        public double BSide { get; }
        public double CSide { get; }
        public bool IsRightTriangle { get; }                    //States if the triangle is right or not. If one of its sides is <= 0, than it cannot be a right triangle

        /// <summary>
        /// Sets two known sides of a triangle. Value a is always a known leg (a or b). c means a Hypotenuse if isHypoKnown is true, otherwise leg a or b
        ///             /|
        ///           c/ |a 
        ///           /_b|
        /// </summary>
        /// <param name="a">always a leg</param>
        /// <param name="b">leg if isHypoKnown is false, hypotenuse otherwise</param>
        /// <param name="isHypoKnown">true if hypotenuse is known, false otherwise</param>
        public Triangle(double a, double b, bool isHypoKnown)
        {
            ASide = a;
            if (isHypoKnown)
            {
                CSide = b;
                BSide = CalcTriangleLeg();
            }
            else
            {
                BSide = b;
                CSide = CalcTriangleHypo();
            }

            IsRightTriangle = (BSide > 0);
        }
        /// <summary>
        /// Finds the unknown leg of a triangle based on Pythagoras theorem  x = (V(c^2 - b^2))
        /// </summary>
        /// <returns>double leg</returns>
        private double CalcTriangleLeg()
        {
            return Math.Round(Math.Sqrt(Math.Pow(CSide, 2) - Math.Pow(ASide, 2)), 1, MidpointRounding.AwayFromZero);
        }
        /// <summary>
        /// Finds the hypotenuse of a triangle based on Pythagoras theorem  x = (V(a^2 + b^2))
        /// </summary>
        /// <returns>double hypotenuse</returns>
        private double CalcTriangleHypo()
        {
            return Math.Round(Math.Sqrt(Math.Pow(ASide, 2) + Math.Pow(BSide, 2)), 1, MidpointRounding.AwayFromZero);
        }
    }
}
