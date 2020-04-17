using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using GeometricShapeInterfaces.interfaces;

namespace GeometricShapeInterfaces.models
{
    class Triangle : Shape
    {
        public Triangle(string shapeType) : base(shapeType)
        {
        }

        public override void CalcArea()
        {
            double s = (Sizes.Sides[0] + Sizes.Sides[1] + Sizes.Sides[2]) / 2;
            Perimeter = Math.Sqrt(s * (s - Sizes.Sides[0]) * (s - Sizes.Sides[1]) *
                                  (s - Sizes.Sides[2]));
        }

        public override bool IsValidShape()
        {
            if (Sizes.Sides[2] > Sizes.Sides[1] + Sizes.Sides[0])
            {
                return true;
            }

            return false;
        }
    }
}
