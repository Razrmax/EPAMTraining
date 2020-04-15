using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricShapeInterfaces.interfaces
{
    interface IShapeDimensions
    {
        double[] Dimenions { get; set; }
        double CalcArea();
        double CalcPerimeter();
    }
}
