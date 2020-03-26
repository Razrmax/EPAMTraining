using DividerIndex.model;
using System;
using System.Linq;


namespace DividerIndex
{
    /// <summary>
    /// Contains Main method for the project, interfaces between user and NumbersArray, FileManager.
    /// </summary>
    class DividerDriver
    {
        static void Main()
        {
            string inputFilePath = @"C:\Users\Maxim\Desktop\Programming\EPAMTraining\Labs\DividerIndex\src\Inlet.in";
            string outputFilePath = @"C:\Users\Maxim\Desktop\Programming\EPAMTraining\Labs\DividerIndex\src\Outlet.in";
            FileManager fileManager = new FileManager();
            string values = fileManager.ReadFile(inputFilePath,3);
            if (values != "")
            {
                fileManager.ProcessInputFile(out int elementsNumber, out int dividend, values, out int[] elements);
                NumbersArray numArray = new NumbersArray(elementsNumber,dividend,elements);
                values = numArray.GetDividers();
                fileManager.WriteFile(values,outputFilePath);
            }

            
            bool exit = false;

            while (!exit)
            {
                DisplayMainMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        values = fileManager.ReadFile(outputFilePath,1);
                        DisplayResult(values);
                        break;

                    case "2":
                        values = fileManager.ReadFile(inputFilePath,1);
                        DisplayResult(values);
                        break;

                    case "3":
                        GetLengthAndDivider(out int elementsNumber, out int dividend);
                        GetElements(out int[] elements, elementsNumber);
                        fileManager.WriteFile(elementsNumber + " " + dividend + "\n", elements, inputFilePath);
                        NumbersArray numArray = new NumbersArray(elementsNumber,dividend,elements);
                        string dividers = numArray.GetDividers();
                        fileManager.WriteFile(dividers, outputFilePath);
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
            Console.WriteLine("List of dividers: ");
            Console.WriteLine(str);
        }

        /// <summary>
        /// Gets from user the N and C values and stores them as elementsNumber. Loops till user enters valid numeric values.
        /// </summary>
        static void GetLengthAndDivider(out int elementsNumber, out int dividend)
        {
            bool exit = false;
            Console.WriteLine("Please enter N and C values delimited by space and press (\"Enter\"):");
            string str = "";
            elementsNumber = 0;
            dividend = 0;

            while (!exit)
            {
                str = Console.ReadLine();
                string[] strArr = str.Split(" ");
                if (strArr.Length == 2 && strArr.All(s => s.All(Char.IsDigit)))
                {
                    elementsNumber = Convert.ToInt32(strArr[0]);
                    dividend = Convert.ToInt32(strArr[1]);
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Wrong input format. Please enter two numbers separated by a \'space\' ");
                }
            }
        }
        /// <summary>
        /// Gets from the user the n numeric elements and returns them as a string. Elements are separated by '\n' character
        /// </summary>
        /// <param name="str">out source value</param>
        static void GetElements(out int[] elements, int elementsNumber)
        {
            elements = new int[elementsNumber];
            Console.WriteLine("Enter {0} values: ", elementsNumber);
            for (int i = 0; i < elementsNumber; i++)
            {
                string input = Console.ReadLine();
                if (input.All(Char.IsDigit) && input != "")
                {
                    elements[i] = Convert.ToInt32(input);
                }
                else
                {
                    Console.WriteLine("Wrong input. Enter a number and press enter");
                    i--;
                }
            }
        }
    }
}
