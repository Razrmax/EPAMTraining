using System;
using System.Collections.Generic;
using System.Text;
using CollectionsLab.interfaces;

namespace CollectionsLab.models.shapes
{
    class Rectangular : GeometricShape, IShapePropertiesCalculator
    {
        public Rectangular(string shapeType, double[] dimensions) : base(shapeType, dimensions)
        {
            CalcAllAProperties();
        }
        public void CalcAllAProperties()
        {
            Perimeter = (Dimensions[0] + Dimensions[1]) * 2;
            Area = Dimensions[0] * Dimensions[1];
        }

        public override string ToString()
        {
            return string.Format("Class GeometricShape: \nShape type: {0}\n" +
                                 "Dimensions: a: {1}\tc: {2}\n" +
                                 "Perimeter: {3}\t\tArea: {4}", ShapeType, Dimensions[0], Dimensions[1], Perimeter, Area);
        }
    }
}
