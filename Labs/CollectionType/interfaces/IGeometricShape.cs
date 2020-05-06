using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionsLab.interfaces
{
    interface IGeometricShape
    {
        string ShapeType { get; set; }
        double[] Dimensions { get; set; }
        double Area { get; set; }
        double Perimeter { get; set; }
    }
}
