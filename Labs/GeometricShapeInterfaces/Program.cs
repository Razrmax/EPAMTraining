using System;
using GeometricShapeInterfaces.models;

namespace GeometricShapeInterfaces
{
    class Program
    {
        static Shape _shape;

        static void Main()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Enter command: ");
                string[] input = Console.ReadLine().Split(" ");
                if (input != null)
                {
                    switch (input[0])
                    {
                        case "exit":
                            exit = true;
                            break;
                        case "help":
                            DisplayHelpMenu();
                            break;
                        case "new":
                            if (!CreateShape(input[1]))
                            {
                                Console.WriteLine("Wrong _shape type argument!");
                            }
                            break;
                        case "save":
                            if (!SaveShape())
                            {
                                Console.WriteLine("Failed saving _shape");
                            }
                            break;
                        case "show":
                            DisplayCurrentShape();
                            break;
                        case "load":
                            LoadShape();
                            break;
                        case "delete":
                            DeleteShape();
                            break;
                    }
                }
            }
                
        }

        private static void DisplayHelpMenu()
        {
            Console.WriteLine("[new + _shape type] - creates new _shape with mentioned type");
            Console.WriteLine("[save + file name] - saves existing _shape to a stated file");
            Console.WriteLine("[load + file name] - loads a _shape from stated file");
            Console.WriteLine("[show] - display information about the current _shape");
            Console.WriteLine("[exit] - exit the program");
            Console.WriteLine("[help] - display this help menu");
        }

        public static bool CreateShape(string type)
        {
            type = type.ToLower();
            switch (type)
            {
                case "rectangle":
                    _shape = new Rectangle();
                    InitializeShape();
                    return true;
                case "triangle":
                    _shape = new Triangle();
                    InitializeShape();
                    return true;
                case "circle":
                    _shape = new Circle();
                    InitializeShape();
                    return true;
                default:
                    return false;
            }
        }

        private static void DisplayCurrentShape()
        {
            Console.WriteLine(_shape != null ? _shape.ToString() : "Shape does not exist");
        }

        public static void InitializeShape()
        {
            int dimensions = 0;
            switch (_shape.ShapeType)
            {
                case "rectangle":
                    dimensions = 2;
                    break;
                case "circle":
                    dimensions = 1;
                    break;
                case "triangle":
                    dimensions = 3;
                    break;
            }

            Console.WriteLine("Please enter {0} dimensions:", _shape.ShapeType);
            double[] input = new double[0];
            while (input.Length != dimensions)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(' '), Double.Parse);
            }


            _shape.Sides = input;
            if (_shape.IsValidShape())
            {
                _shape.CalcArea();
                _shape.CalcPerimeter();
            }
            else
            {
                Console.WriteLine("{0} with these dimensions cannot exist\nShape deleted", _shape.ShapeType);
                _shape = null;
            }
        }

        public static void DeleteShape()
        {
            _shape = null;
        }

        public static bool SaveShape()
        {
            if (_shape != null)
            {
                _shape.SaveToFile();
                return true;
            }

            return false;
        }

        public static void LoadShape()
        {
            if (!_shape.LoadFromFile())
            {
                Console.WriteLine("Failed loading file");
            }
        }
    }
}
