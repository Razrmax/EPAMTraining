namespace TrapezoidShape.model
{
    interface ISidesCalculator
    {
        int CalcArea(int[] sides);
        int CalcPerimeter(int[] sides);
        bool isValidShape(int[] sides);
    }
}
