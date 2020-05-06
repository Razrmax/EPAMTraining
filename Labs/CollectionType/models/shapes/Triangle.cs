using System;
using System.Collections.Generic;
using System.Text;
using CollectionsLab.interfaces;

namespace CollectionsLab.models.shapes
{
    class Triangle : GeometricShape, IShapePropertiesCalculator
    {
        public Triangle(string shapeType, double[] dimensions) : base(shapeType, dimensions)
        {
            CalcAllAProperties();
        }
        public void CalcAllAProperties()
        {
            Perimeter = Dimensions[0] + Dimensions[1] + Dimensions[2];
            Area = Dimensions[3] * Dimensions[1] / 2;
        }

        public override string ToString()
        {
            return string.Format("Class GeometricShape: \nShape type: {0}\n" +
                                 "Dimensions: a: {1}\tb: {2}\tc: {3}\theight: {4}\n" +
                                 "Perimeter: {5}\t\tArea: {6}", ShapeType, Dimensions[0], Dimensions[1], Dimensions[2], Dimensions[3], Perimeter, Area);
        }
    }
}
