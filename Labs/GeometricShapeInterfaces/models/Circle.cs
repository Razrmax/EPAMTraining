using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricShapeInterfaces.models
{
    class Circle : Shape
    {
        public Circle(string shapeType) : base(shapeType)
        {
        }

        public override void CalcPerimeter()
        {
            Perimeter = 2 * Math.PI * Sizes.Sides[0];
        }

        public override void CalcArea()
        {
            Area = Math.PI * Math.Pow(Sizes.Sides[0], 2);
        }

        public override bool IsValidShape()
        {
            return Sizes.Sides.Length == 1;
        }
    }
}
