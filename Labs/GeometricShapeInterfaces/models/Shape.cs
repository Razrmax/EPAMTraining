using System;
using System.Collections.Generic;
using System.Text;
using GeometricShapeInterfaces.interfaces;


namespace GeometricShapeInterfaces.models
{
    abstract class Shape : IShapeDimensions, IValidShape
    {
        public double[] Dimenions { get; set; }

        public double CalcArea()
        {
            throw new NotImplementedException();
        }

        public double CalcPerimeter()
        {
            throw new NotImplementedException();
        }

        public bool IsValidShape()
        {
            throw new NotImplementedException();
        }
    }
}
