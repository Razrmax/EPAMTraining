using System;
using System.IO;
using System.Linq;
using DividerIndex.model;

namespace DividerIndex
{
    class Program
    {
        static void Main()
        {
            string inputFilePath = @"C:\Users\Maxim\Desktop\Programming\EPAMTraining\Labs\DividerIndex\src\Inlet.in";
            string outputFilePath = @"C:\Users\Maxim\Desktop\Programming\EPAMTraining\Labs\DividerIndex\src\Outlet.in";
            WordsArray wordsArray = new WordsArray();
            string str = wordsArray.ReadFile(inputFilePath);
            str = wordsArray.FilterWords(str);
            wordsArray.WriteFile(outputFilePath, str);
            bool exit = false;

            while (!exit)
            {
                DisplayMainMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        str = wordsArray.ReadFile(outputFilePath);
                        DisplayResult(str);
                        break;

                    case "2":
                        str = wordsArray.ReadFile(inputFilePath);
                        DisplayResult(str);
                        break;

                    case "3":
                        str = wordsArray.GetKeyboardInput();
                        wordsArray.WriteFile(inputFilePath, str);
                        str = wordsArray.FilterWords(str);
                        wordsArray.WriteFile(outputFilePath, str);
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
