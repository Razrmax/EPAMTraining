/*The task:
• Develop a class of a Trapezoid geometric shape, defined on a plane by linear dimensions. 
• Provide the functionality to verify the existence of a figure with stated dimensions, implement functions to calculate its area and perimeter. 
• Can use a console application with a command-line interface, WinForms or WPF application as a UI-interface.
Important (!): 
• The geometric shape should not display anything on the screen or read anything from the screen. 
• After creating a shape, you cannot change its linear dimensions.
• There should not be any default constructor since a figure with zero linear dimensions cannot exist. We do not want to create an object in a deliberately erroneous state.
• The comments of the calculation methods should contain a description of the formulas used to calculate them, or the names of such formulas. 
• There must be “prompts for input”, and the display of the result, so that the user understands what is displayed.
 */

using System;
using System.IO.MemoryMappedFiles;
using TrapezoidShape.model;

namespace TrapezoidShape
{
    /// <summary>
    /// Driver class for Trapezoid application
    /// </summary>
    class TrapezoidDriver
    {
        static void Main()
        {
            bool exit = false;
            string input;
            TrapezoidDesigner trapezoidDesigner;
            Trapezoid trapezoid = null;

            while (!exit)
            {
                DisplayMainMenu();
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DisplayNewTrapezoidMenu();
                        while (true)
                        {
                            input = Console.ReadLine();
                            if (input == "1")
                            {
                                GetUserTrapezoidSides(out double a, out double b, out double c,out double d, 4);
                                trapezoidDesigner = new TrapezoidDesigner(a,b,c,d);

                                if (trapezoidDesigner.VerifyTrapezoidProbability() == true)
                                {
                                    trapezoid = new Trapezoid(a,b,c,d);
                                }
                                else
                                {
                                    Console.WriteLine("Trapezoid with stated values cannot exist. Should I try and compute the fourth side? (y/n)");
                                    input = Console.ReadLine().ToLower();
                                    if (input == "y")
                                    {
                                        trapezoidDesigner.ModelLastTrapezoidSide(out d);
                                        Console.WriteLine("Computed d side: {0}", d);
                                    }
                                }
                            }
                            else if (input == "2")
                            {
                                AutoGenerateThreeTrapezoidSides(out double a, out double b, out double c);
                                trapezoidDesigner = new TrapezoidDesigner(a,b,c);
                                double d = trapezoidDesigner.DSide;
                                trapezoid = new Trapezoid(a,b,c,d);
                            }
                            else if (input == "3")
                            {
                                if (trapezoid != null)
                                {
                                    DisplayTrapezoidValues( trapezoid);
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        break;
                    case "2":
                        if (trapezoid != null)
                        {
                            DisplayTrapezoidValues(trapezoid);
                        }
                        break;
                    case "quit":
                        break;
                }
            }

        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("Main menu.");
            Console.WriteLine("1) Create a new Trapezoid\n2)Display values of the Trapezoid\nType 'Quit' to exit");
        }

        static void DisplayNewTrapezoidMenu()
        {
            Console.WriteLine("1) Enter all sides of a triangle manually\n2) Auto-generate all four sides of a probable Trapezoid\n3) Display current trapezoid values\nDefault - previous menu");
        }

        static void GetUserTrapezoidSides(out double a, out double b, out double c, out double d, int length)
        {
            int input;
            int[] userValues = new int[length];
            Console.WriteLine("Enter each of the four sides (a,b,c,d) of a trapezoid. Minimum value is 1, maximum value is 8. Sides a and b cannot be of equal length: ");
            for (int i = 0; i < length; i++)
            {
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    if (input < 1 || input > 8)
                    {
                        Console.WriteLine("Wrong value, try again");
                        i--;
                        continue;
                    }
                    userValues[i] = input;
                    if (i == 1 && (userValues[0] == userValues[1]))
                    {
                        Console.WriteLine("a cannot be equal to b, try new value");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid value, try again");
                    i--;
                }
            }

            a = userValues[0];
            b = userValues[1];
            c = userValues[2];
            if (length == 4)
            {
                d = userValues[3];
            }
            else
            {
                d = 0;
            }
        }

        static void AutoGenerateThreeTrapezoidSides(out double a, out double b, out double c)
        {
            Random rand = new Random();
            int[] userValues = new int[3];
            for (int i = 0; i < 3; i++)
            {
                userValues[i] = rand.Next(1, 8);
            }

            a = userValues[0];
            b = userValues[1];
            c = userValues[2];

            while (b == a)
            {
                b = rand.Next(1, 8);
            }
        }

        static void DisplayTrapezoidValues(Trapezoid trapezoid)
        {
            Console.WriteLine("Dimensions of trapezoid");
            Console.WriteLine("a: {0}", trapezoid.ASide);
            Console.WriteLine("b: {0}", trapezoid.BSide);
            Console.WriteLine("c: {0}", trapezoid.CSide);
            Console.WriteLine("d: {0}", trapezoid.DSide);
            Console.WriteLine("Area: {0:1N}", trapezoid.Area);
            Console.WriteLine("Perimeter: {0:1N}", trapezoid.Perimeter);
        }
    }
}
