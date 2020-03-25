using System;
using System.IO;
using System.Linq;
using DividerIndex.model;


namespace DividerIndex
{
    class NumbersArrayDriver
    {
        static void Main()
        {
            string inputFilePath = @"C:\Users\Maxim\Desktop\Programming\EPAMTraining\Labs\DividerIndex\src\Inlet.in";
            string outputFilePath = @"C:\Users\Maxim\Desktop\Programming\EPAMTraining\Labs\DividerIndex\src\Outlet.in";
            NumbersArray numArray = new NumbersArray();
            string str = numArray.ReadFile(inputFilePath,out int n, out int divider);
            str = numArray.FindDividers(str);
            numArray.WriteFile(outputFilePath, str);
            bool exit = false;

            while (!exit)
            {
                DisplayMainMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        str = numArray.ReadFile(outputFilePath);
                        DisplayResult(str);
                        break;

                    case "2":
                        str = numArray.ReadFile(inputFilePath);
                        DisplayResult(str);
                        break;

                    case "3":
                        str = numArray.GetKeyboardInput();
                        numArray.WriteFile(inputFilePath, str);
                        str = numArray.FilterWords(str);
                        numArray.WriteFile(outputFilePath, str);
                        break;

                    default:
                        exit = true;
                        break;
                }
            }
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("Main menu");
            Console.WriteLine("1) Display contents of Outlet.in\n2) Display contents of Inlet.in\n3) Edit Inlet.in");
            Console.WriteLine("Any other key to quit");
        }

        static void DisplayResult(string str)
        {
            Console.WriteLine("Filtered value, every word contains at less 2 same chars: ");
            Console.WriteLine(str);
        }
    }
}
