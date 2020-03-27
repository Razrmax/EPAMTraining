using System;

namespace TrapezoidShape.model
{
    class Triangle
    {
        public double ASide { get; }
        public double BSide { get; }
        public double CSide { get; }
        /// <summary>
        /// Sets two known sides of a triangle, if hypo is true, than a and c are initiated, if false, than a and b are initiated
        /// </summary>
        /// <param name="a">always a leg</param>
        /// <param name="b">leg if hypoKnown is false, hypotenuse otherwise</param>
        /// <param name="hypoKnown">true if hypotenuse is known, false otherwise</param>
        public Triangle(double a, double b, bool hypoKnown)
        {
            if (hypoKnown)
            {
                ASide = a;
                CSide = b;
                BSide = FindThirdSide();
            }
            else
            {
                ASide = a;
                BSide = b;
                CSide = FindThirdSide();
            }
        }
        /// <summary>
        /// Finds the third  unknown side of a Triangle based on Pythagoras theorem
        /// </summary>
        /// <returns>int third side</returns>
        public double FindThirdSide()
        {
            return CSide == 0 ? CalcTriangleHypo() : CalcTriangleLeg();
        }
        /// <summary>
        ///                                                                        _____________
        /// Finds the unknown leg of a triangle based on Pythagoras theorem  x = (V(c^2 - b^2))
        /// </summary>
        /// <returns>int leg</returns>
        private double CalcTriangleLeg()
        {
            double knownLeg = BSide == 0 ? BSide : ASide;
            return Math.Round(Math.Sqrt(Math.Pow(CSide, 2) - Math.Pow(knownLeg, 2)),1);
        }
        /// <summary>
        ///                                                                       ____________  
        /// Finds the hypotenuse of a triangle based on Pythagoras theorem  x = (V(a^2 + b^2))
        /// </summary>
        /// <returns>int hypotenuse</returns>
        private double CalcTriangleHypo()
        {
            return Math.Round(Math.Sqrt(Math.Pow(ASide, 2) + Math.Pow(BSide, 2)),1);
        }
    }
}
