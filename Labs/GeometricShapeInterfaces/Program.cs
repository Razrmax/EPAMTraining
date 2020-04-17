using System;
using System.Security.Cryptography.X509Certificates;
using GeometricShapeInterfaces.models;

namespace GeometricShapeInterfaces
{
    class Program
    {
        static Shape shape = null;

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                if (shape == null)
                {
                    Console.WriteLine("Enter new shape type: ");
                    string input = Console.ReadLine();
                    switch (input)
                    {

                        case "exit":
                            exit = true;
                            break;
                        default:
                            CreateShape(input);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Enter dimensions: ");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "exit":
                            exit = true;
                            break;
                        default:
                            CreateShape(input);
                            break;
                    }
                }
            }
        }

        public static bool CreateShape(string type)
        {
            type = type.ToLower();
            switch (type)
            {
                case "rectangle":
                    shape = new Rectangle(type);
                    return true;
                case "triangle":
                    shape = new Triangle(type);
                    return true;
                case "circle":
                    shape = new Circle();
                    return true;
                default:
                    return false;
            }
        }
    }
}
