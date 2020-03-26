using System;
using System.Collections.Generic;
using System.Text;

namespace TrapezoidShape.model
{
    /// <summary>
    /// Contains methods and fields to design the probability of the existence for Trapezoid with user specified dimensions (based on the type of shape).
    /// There are two shapes of trapezoids: Right, and Isosceles.
    /// </summary>
    class TrapezoidDesigner : IVerifyTrapezoidProbability
    {
        public string TrapezoidType { get; set; }

        public TrapezoidDesigner(string trapezoidType)
        {
            TrapezoidType = trapezoidType;
        }
        /// <summary>
        /// Verify the probability of a trapezoid with set length values for its 4 sides
        /// </summary>
        /// <param name="a">Base 1</param>
        /// <param name="b">Base 2</param>
        /// <param name="c">Lateral 1</param>
        /// <param name="d">Lateral 2</param>
        /// <returns></returns>
        public bool VerifyTrapezoidProbability(int a, int b, int c, int d)
        {
            if (a == b || (a == c & b == c))
            {
                return false;
            }

            ModelLastTrapezoidSide(a,b,c, out int x);
            return x == d;
        }
        /// <summary>
        /// Models the probable last side of trapezoid (lateral side No.2 ot d), based on its type. Takes in 3 parameters (length of two bases and one lateral side),
        /// and out parameter for d (the required lateral side)
        /// </summary>
        /// <param name="a">Base 1</param>
        /// <param name="b">Base 2</param>
        /// <param name="c">Lateral 1</param>
        /// <param name="d">Lateral 2</param>
        /// <param name="TrapezoidType"></param>
        public void ModelLastTrapezoidSide(int a, int b, int c, out int d)
        {
            d = 0;
            if (TrapezoidType.Equals("Right"))
            {
                Triangle triangle = new Triangle(Math.Abs(a - b), c, false);
                d = triangle.CSide;
            }
            else if (TrapezoidType.Equals("Isosceles"))
            {
                Triangle triangle = new Triangle(Math.Abs(a - b) / 2,c,true);
                d = triangle.BSide;
            }
        }
    }
}
