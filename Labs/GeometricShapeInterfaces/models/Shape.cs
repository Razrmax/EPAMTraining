using System;
using System.IO;
using GeometricShapeInterfaces.interfaces;


namespace GeometricShapeInterfaces.models
{
    class Shape : Dimensions, IValidShape, IFileOperations
    {
        protected readonly string FilePath =
            @"C:\Users\Maxim\Desktop\Programming\EPAMTraining\Labs\GeometricShapeInterfaces\storage\";
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

        public void SaveToFile(string fileName)
        {
            File.WriteAllText(FilePath + fileName, this.ToString());
        }

        public bool LoadFromFile(string fileName)
        {
            if (File.Exists(FilePath+fileName))
            {
                string[] fileContents = File.ReadAllText(FilePath).Split("\n");
                SetDimensions(new double[] {Convert.ToDouble(fileContents[0].Split("\t"))});
                ShapeType = fileContents[1];
                Perimeter = Convert.ToDouble(fileContents[2]);
                Area = Convert.ToDouble(fileContents[3]);
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return "\nType of the shape: " + ShapeType + "\n" + "Sides:\n" + Sides.ToString() + "\nPerimeter: " + Perimeter + "\nArea: " + Area;
        }
    }
}
