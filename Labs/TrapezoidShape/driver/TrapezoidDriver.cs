/*The task:
• Develop a class of a Trapezoid geometric shape, defined on a plane by linear dimensions. 
• Provide the functionality to verify the existence of a figure with stated dimensions, implement functions to calculate its area and perimeter. 
• Can use a console application with a command-line interface, WinForms or WPF application as a UI-interface.
Important (!): 
• The geometric shape should not display anything on the screen or read anything from the screen. 
• After creating a shape, you cannot change its linear dimensions.
• There should not be any default constructor since a figure with zero linear dimensions cannot exist. We do not want to create an object in a deliberately erroneous state.
• The comments of the calculation methods should contain a description of the formulas used for calculations, or the names of such formulas. 
• The application prompts user input, and displays the result, so that the user understands what is displayed.
 */

using System;
using TrapezoidShape.model;

namespace TrapezoidShape.driver
{
    /// <summary>
    /// Driver class for Trapezoid application
    /// </summary>
    class TrapezoidDriver
    {
        static void Main()
        {
            bool exit = false;
            
            Trapezoid trapezoid = null;

            while (!exit)
            {
                DisplayMainMenu();
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                        GetUserTrapezoidSides(out double a, out double b, out double c, out double d, out double h);
                        if (IsValidTrapezoid(a,b,c,d,h))
                        {
                            Console.WriteLine("Trapezoid can exist.");
                            trapezoid = new Trapezoid(a, b, c, d, h);
                        }
                        else
                        {
                            Console.WriteLine("Trapezoid with stated values cannot exist.");
                            trapezoid = null;
                        }
                        break;
                    case "2":
                        if (trapezoid != null)
                        {
                            DisplayTrapezoidValues(trapezoid);
                        }
                        else
                        {
                            Console.WriteLine("Trapezoid has not been stored.");
                        }
                        break;
                    case "q":
                        exit = true;
                        break;
                }
            }

        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("Main menu.");
            Console.WriteLine("1) Create a new Trapezoid\n2) Display values of the Trapezoid\n'Q' to exit");
        }

        static void GetUserTrapezoidSides(out double a, out double b, out double c, out double d, out double h)
        {
            double[] userValues = new Double[5];
            Console.WriteLine(@"     ____b______"); 
            Console.WriteLine(@"    /|          |\");
            Console.WriteLine(@"  c/ |h         | \d");
            Console.WriteLine(@"  /__|__a_______|__\");
            Console.WriteLine("Please Enter each of the four sides (a,b,c,d) of a trapezoid as illustrated above (from 1 to 8), and a h h: ");
            
            for (int i = 0; i < userValues.Length; i++)
            {
                try
                {
                    double input = Convert.ToDouble(Console.ReadLine());
                    if (input < 1 || input > 8)
                    {
                        Console.WriteLine("Wrong value, try again");
                        i--;
                        continue;
                    }

                    userValues[i] = Math.Round(input,1,MidpointRounding.AwayFromZero);
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
            d = userValues[3];
            h = userValues[4];
        }
        static void DisplayTrapezoidValues(Trapezoid trapezoid)
        {
            Console.WriteLine("Dimensions of trapezoid");
            Console.WriteLine("a: {0}", trapezoid.ASide);
            Console.WriteLine("b: {0}", trapezoid.BSide);
            Console.WriteLine("c: {0}", trapezoid.CSide);
            Console.WriteLine("d: {0}", trapezoid.DSide);
            Console.WriteLine("Area: {0:N1}", trapezoid.Area);
            Console.WriteLine("Perimeter: {0:N1}", trapezoid.Perimeter);
        }

        /// <summary>
        /// Calculates the trapezoid's last side (x). a, b, c, and d are sides of a probable Trapezoid as illustrated below. h is its h.
        /// Creates two triangles. Than using triangles finds the unknown leg l1 of the first triangle. Than finds the leg of a 2nd triangle (l2).
        /// After the 2nd triangle's 2 sides are known (h and l2), calculates its third side (or d) using the Pythagoras theorem: d = V(h^2 + l2^2).
        /// Returns true if resulting value equals d, false otherwise.
        /// </summary>
        /// <param name="a">bigger base side a</param>
        /// <param name="b">smaller base side b</param>
        /// <param name="c">lateral side c</param>
        /// <param name="d">lateral side d</param>
        /// <param name="h">height h</param>
        /// <returns>true if shape is a valid Trapezoid, false if otherwise</returns>
        //       ____b______
        //      /|          |\ 
        //    c/ |h         | \d(x)
        //    /l1|__a_______|l2\
        static bool IsValidTrapezoid(double a, double b, double c, double d, double h)
        {
            if (a == b)
            {
                return false;
            }
            Triangle triangle = new Triangle(h,c,true);
            double l1 = triangle.BSide;
            double l2 = a - b - l1;
            Triangle triangle2 = new Triangle(l2,h,false);
            if (!triangle2.IsRightTriangle)
            {
                return false;
            }
            double x = triangle2.CSide;
            return x == d;
        }
    }
}
