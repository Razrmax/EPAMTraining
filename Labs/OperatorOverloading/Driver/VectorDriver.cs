using OperatorOverloading.exceptions;
using OperatorOverloading.model;
using System;

namespace OperatorOverloading
{
    class VectorDriver
    {
        static void Main()
        {
            bool exit = false;
            Vector3D[] vectors = { null, null, null };

            while (!exit)
            {
                DisplayMainMenu();
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        while (input != "")
                        {
                            if (vectors[0] == null)
                            {
                                Console.WriteLine("Vectors have not been assigned values");
                                break;
                            }
                            else
                            {
                                DisplayExistingVectors();
                                input = Console.ReadLine();
                                switch (input)
                                {
                                    case "1":
                                        foreach (Vector3D v in vectors)
                                        {
                                            DisplaySpecifiedVector(v);
                                        }
                                        break;
                                    case "2":
                                        Console.WriteLine("Please enter the specific math operator (+, -, *)");
                                        try
                                        {
                                            input = Console.ReadLine();
                                            ValidateArithmeticOperator(input);
                                            if (input == "+")
                                            {
                                                vectors[2] = vectors[0] + vectors[1];
                                            }
                                            else if (input == "-")
                                            {
                                                vectors[2] = vectors[0] - vectors[1];
                                            }
                                            else
                                            {
                                                Console.WriteLine("Please choose a vector to multiply:");
                                                int index = Convert.ToInt32(Console.ReadLine());
                                                while (index >= 2 && index <= 0)
                                                {
                                                    index = Convert.ToInt32(Console.ReadLine());
                                                }
                                                Console.WriteLine("Please enter the scalar operand value: ");
                                                double scal = GetDouble();
                                                vectors[2] = vectors[0] * scal;
                                            }

                                            Console.WriteLine("Result: " + vectors[2]);

                                        }
                                        catch (InvalidOperatorException)
                                        {
                                        }
                                        break;
                                    case "3":
                                        Console.WriteLine("Enter logical operator according to pattern\nVector1 ? Vector2 = result\nwhere ? is a logical operator");
                                        try
                                        {
                                            string oper = Console.ReadLine();
                                            ValidateLogicalOperator(oper);
                                            switch (oper)
                                            {
                                                case "<":
                                                    Console.WriteLine(vectors[0] < vectors[1]);
                                                    break;
                                                case ">":
                                                    Console.WriteLine(vectors[0] > vectors[1]);
                                                    break;
                                                case "<=":
                                                    Console.WriteLine(vectors[0] <= vectors[1]);
                                                    break;
                                                case ">=":
                                                    Console.WriteLine(vectors[0] >= vectors[1]);
                                                    break;
                                                case "==":
                                                    Console.WriteLine(vectors[0] == vectors[1]);
                                                    break;
                                                case "!=":
                                                    Console.WriteLine(vectors[0] != vectors[1]);
                                                    break;
                                            }
                                        }
                                        catch (InvalidOperatorException)
                                        {
                                        }
                                        break;

                                }
                            }
                        }

                        break;
                    case "2":
                        for (int i = 0; i < 2; i++)
                        {
                            if (vectors[i] == null)
                            {
                                Console.WriteLine("Please enter values (X Y Z) for Vector {0}: ", i + 1);
                                double x = GetDouble();
                                double y = GetDouble();
                                double z = GetDouble();
                                vectors[i] = new Vector3D(x, y, z);
                            }
                        }
                        break;


                    case "q":
                        exit = true;
                        break;
                }
            }

        }

        private static void ValidateLogicalOperator(string oper)
        {
            if (oper != "<" && oper != ">" && oper != "<=" && oper != ">=" && oper != "==" && oper != "!=")
            {
                throw new InvalidOperatorException(oper);
            }
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("Main menu");
            Console.WriteLine("1) Display existing vectors\n2) Create new Vectors");
        }

        static void DisplayExistingVectors()
        {
            Console.WriteLine("1) Show values for vetrices\n2) Perform calculations with vetrices\n3) Perform logical operations with vetrices");
        }

        static void DisplaySpecifiedVector(Vector3D v)
        {
            if (v == null)
            {
                Console.WriteLine("Vector not initialized");
            }
            else
            {
                Console.WriteLine(v.ToString());
            }
        }

        private static int GetNumber()
        {
            string str = Console.ReadLine();
            while (int.TryParse(str, out _) == false)
            {
                Console.WriteLine("Error, please enter numeric value!");
                str = Console.ReadLine();
            }

            return int.Parse(str);
        }

        private static double GetDouble()
        {
            string str = Console.ReadLine();
            while (double.TryParse(str, out _) == false)
            {
                Console.WriteLine("Error, please enter numeric value!");
                str = Console.ReadLine();
            }

            return double.Parse(str);
        }

        private static void ValidateArithmeticOperator(string input)
        {
            if (input != "-" && input != "+" && input != "*")
            {
                throw new InvalidOperatorException(input);
            }
        }
    }
}
