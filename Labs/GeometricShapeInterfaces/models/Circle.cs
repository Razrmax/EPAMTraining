using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricShapeInterfaces.models
{
    class Circle : Shape
    {
        public Circle()
        {
            ShapeType = "circle";
        }
        public override void CalcPerimeter()
        {
            Perimeter = 2 * Math.PI * Sides[0];
        }

        public override void CalcArea()
        {
            Area = Math.PI * Math.Pow(Sides[0], 2);
        }

        public override bool IsValidShape()
        {
            return Sides.Length == 1;
        }
    }
}
