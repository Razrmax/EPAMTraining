using System;

namespace GeometricShapeInterfaces.models
{
    class Triangle : Shape
    {
        public Triangle()
        {
            ShapeType = "triangle";
        }

        public override void CalcArea()
        {
            double s = (Sides[0] + Sides[1] + Sides[2]) / 2;
            Area = Math.Sqrt(s * (s - Sides[0]) * (s - Sides[1]) *
                                  (s - Sides[2]));
        }

        public override bool IsValidShape()
        {
            if (Sides[2] > Sides[1] + Sides[0])
            {
                return true;
            }

            return false;
        }
    }
}
