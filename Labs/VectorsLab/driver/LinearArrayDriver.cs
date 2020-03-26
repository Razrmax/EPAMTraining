using System;
using VectorsLab.model;

/*
A linear array containing N integers is given. From this array, select those elements which are located between the minimum and maximum elements and store them in array B.
If elements between the minmax are empty, store -1 instead.
Input/output specifications:
Input (Inlet.in)
N
Elements of array A as a string, separated by space
Output (Outlet.out):
Elements of array B separated by newline character).*/

namespace VectorsLab.driver
{
    class LinearArrayDriver
    {
        static void Main()
        {
            string inputFilePath = @"C:\Users\Maxim\Desktop\Programming\EPAMTraining\Labs\VectorsLab\src\Inlet.in";
            string outputFilePath = @"C:\Users\Maxim\Desktop\Programming\EPAMTraining\Labs\VectorsLab\src\Outlet.in";
            LinearArray linearArray = new LinearArray();
            string str = linearArray.ReadFile(inputFilePath);
            str = linearArray.CopyBetweenMinMaxValues(str);
            linearArray.WriteFile(outputFilePath, str);
            bool exit = false;


            while (!exit)
            {
                DisplayMainMenu();
                string choice = Console.ReadLine();



                switch (choice)
                {
                    case "1":
                        str = linearArray.ReadFile(outputFilePath);
                        DisplayValues(str);
                        break;
                    case "2":
                        str = linearArray.ReadFile(inputFilePath);
                        DisplayValues(str);
                        break;
                    case "3":
                        str = linearArray.GetKeyboardInput();
                        linearArray.WriteFile(inputFilePath, str);
                        str = linearArray.ReadFile(inputFilePath);
                        str = linearArray.CopyBetweenMinMaxValues(str);
                        linearArray.WriteFile(outputFilePath, str);
                        break;
                    case "4":
                        str = linearArray.GenerateRandomValues(str);
                        linearArray.WriteFile(inputFilePath, str);
                        str = linearArray.ReadFile(inputFilePath);
                        str = linearArray.CopyBetweenMinMaxValues(str);
                        linearArray.WriteFile(outputFilePath, str);

                        break;
                    default:
                        exit = true;
                        break;
                }
            }
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("Vectors Lab");
            Console.WriteLine("1) Display contents of Outlet.in\n2) Display contents of Inlet.in\n3) Edit Inlet.in manually\n4) Auto generate Inlet.in");
            Console.WriteLine("Any other key to quit");
        }

        static void DisplayValues(string str)
        {
            Console.WriteLine("Values of the array:");
            Console.WriteLine(str);
        }
    }
}













