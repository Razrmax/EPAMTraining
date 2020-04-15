using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricShapeInterfaces.interfaces
{
    interface IFileOperations : IShapeDimensions
    {
        bool SaveToFile();
        double[] LoadFromFile();
    }
}
