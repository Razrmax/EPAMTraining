using System;
using CollectionsLab.interfaces;

namespace CollectionsLab.models
{
    [Serializable]
    public class GeometricShape : IGeometricShape, IComparable<GeometricShape>
    {
        public string ShapeType { get; set; }
        public double[] Dimensions { get; set; }
        public double Area { get; set; }
        public double Perimeter { get; set; }

        public GeometricShape()
        {
        }

        public GeometricShape(string shapeType, double[] dimensions)
        {
            ShapeType = shapeType;
            Dimensions = dimensions;
        }

        public int CompareTo(GeometricShape other)
        {
            return this.Area.CompareTo(other.Area);
        }

        public override string ToString()
        {
            return string.Format("Class GeometricShape: \nShape type: {0}\nDimensions: {1}", ShapeType, Dimensions);
        }
    }
}
