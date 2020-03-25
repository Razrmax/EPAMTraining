using System;
using VectorsLab.model;

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
            str = linearArray.FilterIntegerValues(str);
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
                        str = linearArray.FilterIntegerValues(str);
                        linearArray.WriteFile(outputFilePath, str);
                        break;
                    case "4":
                        linearArray.GenerateRandomValues(str);
                        StoreInputValues(inputFilePath, ref str, linearArray);
                        ProcessAndSave(inputFilePath,str,linearArray);
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

        static void StoreInputValues(string filePath, ref string str, LinearArray linearArray)
        {
            linearArray.WriteFile(filePath, str);
            str = linearArray.ReadFile(filePath);
        }

        static void ProcessAndSave(string filePath, string str, LinearArray linearArray)
        {
            
        }
    }
}













