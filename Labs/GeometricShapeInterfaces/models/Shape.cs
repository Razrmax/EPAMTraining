using System;
using System.IO;
using GeometricShapeInterfaces.interfaces;


namespace GeometricShapeInterfaces.models
{
    class Shape : Dimensions, IValidShape, IFileOperations
    {
        protected readonly string FilePath =
            @"C:\Users\Maxim\Desktop\Programming\EPAMTraining\Labs\GeometricShapeInterfaces\storage\shape.txt";

        public Shape(string shapeType)
        {
            ShapeType = shapeType;
        }

        public Dimensions Sizes { get; private set; }
        public string ShapeType { get; set; }

        public virtual bool IsValidShape()
        {
            if ((Math.Abs(Sizes.Sides[0] - Sizes.Sides[2]) > 0.01) || (Math.Abs(Sizes.Sides[1] - Sizes.Sides[3]) > 0.01))
            {
                return false;
            }

            return true;
        }

        public void SaveToFile()
        {
            File.WriteAllText(FilePath, Sizes.ToString() + "\n" + ShapeType);
        }

        public void LoadFromFile()
        {
            if (File.Exists(FilePath))
            {
                string[] fileContents = File.ReadAllText(FilePath).Split("\n");
                Sizes.SetDimensions(new double[] {Convert.ToDouble(fileContents[0].Split("\t"))});
                ShapeType = fileContents[1];
            }
            else
            {
                Console.WriteLine("Cannot load file");
            }
        }

        public override string ToString()
        {
            return Sizes.ToString() + "\nType of the shape: " + ShapeType + "\nPerimeter: " + Perimeter + "\nArea: " + Area;
        }
    }
}
