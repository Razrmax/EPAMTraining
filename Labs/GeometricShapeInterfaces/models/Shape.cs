using GeometricShapeInterfaces.interfaces;
using System;
using System.IO;
using System.Linq;


namespace GeometricShapeInterfaces.models
{
    class Shape : Dimensions, IValidShape, IFileOperations
    {
        protected readonly string FilePath =
            @"C:\Users\Maxim\Desktop\Programming\EPAMTraining\Labs\GeometricShapeInterfaces\storage\shape.txt";
        public string ShapeType { get; set; }

        public Shape(double[] sides) : base(sides)
        {
        }

        public Shape()
        {
        }

        public virtual bool IsValidShape()
        {
            if (Sides[0] > 0 && Sides[1] > 0)
            {
                return true;
            }

            return false;
        }

        public void SaveToFile()
        {
            File.WriteAllText(FilePath, this.ToString());
        }

        public bool LoadFromFile()
        {
            if (File.Exists(FilePath))
            {
                string[] fileContents = File.ReadAllText(FilePath).Split("\n");
                SetDimensions(new double[] { Convert.ToDouble(fileContents[0].Split("\t")) });
                ShapeType = fileContents[1];
                Perimeter = Convert.ToDouble(fileContents[2]);
                Area = Convert.ToDouble(fileContents[3]);
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return "\nType of the shape: " + ShapeType + "\n" + "Sides:\n" + String.Join(" ", Sides.Select(p => p.ToString()).ToArray()) + "\nPerimeter: " + Perimeter + "\nArea: " + Area;
        }
    }
}
