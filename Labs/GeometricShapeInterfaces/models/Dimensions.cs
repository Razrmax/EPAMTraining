using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeometricShapeInterfaces.interfaces;

namespace GeometricShapeInterfaces.models
{
    class Dimensions : IShapeDimensions
    {
        public double[] Sides { get; set; }
        public double Perimeter { get; protected set; }
        public double Area { get; protected set; }

        public override string ToString()
        {
            string str = "";
            foreach (var v in Sides)
            {
                str += v + "\t";
            }

            return str;
        }

        public virtual void CalcPerimeter()
        {
            foreach (var v in Sides)
            {
                Perimeter += v;
            }
        }

        public virtual void CalcArea()
        {
            Area = Sides[0] * Sides[1];
        }

        public void SetDimensions(double[] measurements)
        {
            Sides = measurements;
        }
    }
}
