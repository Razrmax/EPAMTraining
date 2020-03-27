using System;
using System.Collections.Generic;
using System.Text;

namespace TrapezoidShape.model
{
    /// <summary>
    /// Computes the probability of the existence for Trapezoid with user specified dimensions (based on the type of shape).
    /// First user 
    /// There are two shapes of trapezoids: Right, and Isosceles.
    /// </summary>
    class TrapezoidDesigner : IVerifyTrapezoidProbability
    {
        public string TrapezoidType { get; set; }
        public double ASide { get; set;  }
        public double BSide { get; set;  }
        public double CSide { get; set;  }
        public double DSide { get; set; }
        public bool IsProbableShape { get; }

        /// <summary>
        /// Gets from the user the four dimensions of a trapezoid and stores them. If c == d than the TrapezoidType = Isosceles, Right otherwise
        /// </summary>
        /// <param name="trapezoidType"></param>
        public TrapezoidDesigner(double a, double b, double c, double d)
        {
            ASide = a;
            BSide = b;
            CSide = c;
            DSide = d;
            if (c == d)
            {
                TrapezoidType = "Isosceles";
            }
            else
            {
                TrapezoidType = "Right";
            }

            IsProbableShape = VerifyTrapezoidProbability();
        }

        /// <summary>
        /// Gets from the user the three sides of a trapezoid. Automatically calculates the fourth. Type of the trapezoid is set as Right by default
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public TrapezoidDesigner(double a, double b, double c)
        {
            ASide = a;
            BSide = b;
            CSide = c;
            TrapezoidType = "Right";
            ModelLastTrapezoidSide(out double d);
            DSide = d;
            IsProbableShape = VerifyTrapezoidProbability();
        }

        public TrapezoidDesigner(string trapezoidType)
        {
            TrapezoidType = trapezoidType;
        }
        /// <summary>
        /// Verifies the probability of a trapezoid with set length values for its 4 sides. Calculates the 2nd leg (or d) and compares it to the d entered by user.
        /// </summary>
        /// <param name="a">Base 1</param>
        /// <param name="b">Base 2</param>
        /// <param name="c">Lateral 1</param>
        /// <param name="d">Lateral 2</param>
        /// <returns></returns>
        public bool VerifyTrapezoidProbability()
        {
            if (ASide == BSide || (ASide == CSide & BSide == CSide))
            {
                return false;
            }

            ModelLastTrapezoidSide(out double x);
            return x == DSide;
        }
        /// <summary>
        /// Models the probable last side of trapezoid (lateral side No.2 ot d), based on its type. Takes out parameter for d (the required lateral side)
        /// </summary>
        /// <param name="a">Base 1</param>
        /// <param name="b">Base 2</param>
        /// <param name="c">Lateral 1</param>
        /// <param name="d">Lateral 2</param>
        /// <param name="TrapezoidType"></param>
        public void ModelLastTrapezoidSide(out double d)
        {
            d = 0;
            if (TrapezoidType.Equals("Right"))
            {
                Triangle triangle = new Triangle(Math.Abs(ASide - BSide), CSide, false);
                d = triangle.CSide;
            }
            else if (TrapezoidType.Equals("Isosceles"))
            {
                Triangle triangle = new Triangle(Math.Abs(ASide - BSide) / 2,CSide,true);
                d = triangle.BSide;
            }
        }
    }
}
