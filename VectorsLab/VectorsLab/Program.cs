using System;
using System.IO;


namespace VectorsLab
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] filteredValues;
            string sentence;
            bool isContinue = true;

            while (isContinue)
            {
                Console.WriteLine("1) Read values from file named Inlet.in\t\t\t2) Input values from user's keyboard\nAny other key to quit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        sentence = ReadFile();
                        filteredValues = ConvertToIntegers(sentence);
                        filteredValues = FilterIntegerValues(filteredValues);
                        DisplayResult(filteredValues);
                        continue;

                    case "2":
                        sentence = GetUserInput();
                        filteredValues = ConvertToIntegers(sentence);
                        filteredValues = FilterIntegerValues(filteredValues);
                        DisplayResult(filteredValues);
                        break;

                    default:
                        isContinue = false;
                        break;
                }
            }
        }

        static void DisplayResult(int[] filteredValues)
        {
            Console.WriteLine("The following are the elements located between the greatest and smallest values of the array:");
            foreach (int i in filteredValues)
            {
                Console.WriteLine(i);
            }
        }

        static private int[] FilterIntegerValues(int[] rawValues)
        {
            int length = rawValues.Length;

            if (length == 2)
            {
                return new int[] { -1 };
            }


            int smallest = rawValues[0], greatest = smallest;

            foreach (int n in rawValues)
            {
                if (smallest > n)
                {
                    smallest = n;
                }
                if (greatest < n)
                {
                    greatest = n;
                }
            }

            if (smallest == greatest)
            {
                return new int[] { -1 };
            }

            int occurenceCounter = 0;                   //ЧИсло повторений самого высокого или низкого элемента в массиве

            foreach (int n in rawValues)
            {
                if (n == smallest || n == greatest)
                {
                    occurenceCounter++;
                }
            }

            if (rawValues.Length == occurenceCounter)
            {
                return new int[] { -1 };
            }

            int[] filteredValues = new int[rawValues.Length - occurenceCounter];

            for (int i = 0, j = 0; i < filteredValues.Length; i++, j++)
            {
                if (rawValues[j] == smallest || rawValues[j] == greatest)
                {
                    i--;
                }
                else
                {
                    filteredValues[i] = rawValues[j];
                }
            }

            return filteredValues;
        }

        static private int[] ConvertToIntegers(string values)
        {
            string[] valuesArray = values.Split(" ");
            int[] integersArray = new int[valuesArray.Length];

            for (int i = 0; i < valuesArray.Length; i++)
            {
                integersArray[i] = Convert.ToInt32(valuesArray[i]);
            }
            return integersArray;
        }

        static private string ReadFile()
        {
            string contents = File.ReadAllText("Inlet.in");
            return contents;
        }

        static private string GetUserInput()
        {
            do
            {
                Console.WriteLine("Please enter the string of integer values, each delimited by a single space (\" \"):");
                string inputValue = Console.ReadLine();
                if (inputValue != "")
                {
                    return inputValue;
                }
                
            } while (true);
            
        }
    }
}
