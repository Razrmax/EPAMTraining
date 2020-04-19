namespace GeometricShapeInterfaces.interfaces
{
    interface IShapeDimensions
    {
        double[] Sides { get; set; }
        void CalcArea();
        void CalcPerimeter();
    }
}
