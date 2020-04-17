using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricShapeInterfaces.interfaces
{
    interface IShapeDimensions
    {
        double[] Sides { get; set; }
        void CalcArea();
        void CalcPerimeter();
    }
}
