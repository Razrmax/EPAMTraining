using System;
using System.Collections.Generic;
using System.Text;
using CollectionsLab.interfaces;

namespace CollectionsLab.models.shapes
{
    class Circle : GeometricShape, IShapePropertiesCalculator
    {
        public Circle(string shapeType, double[] dimensions) : base(shapeType, dimensions)
        {
            CalcAllAProperties();
        }
        public void CalcAllAProperties()
        {
            Perimeter = 2 * Math.PI * (Dimensions[0]/2);
            Area =  Math.PI * Math.Pow(Dimensions[0]/2, 2);
        }

        public override string ToString()
        {
            return string.Format("Class GeometricShape: \nShape type: {0}\n" +
                                 "Dimensions: Diameter: {1}\tRadius: {2}" +
                                 "Circumference: {3}\t\tArea: {4}", ShapeType, Dimensions[0], Dimensions[0]/2, Perimeter, Area);
        }
    }
}
