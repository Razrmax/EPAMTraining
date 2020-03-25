using System;
using System.IO;

namespace VectorsLab.model
{
    abstract class AbstractLinearArray : IDataProcessor
    {
        public string ReadFile(string filePath)
        {
            string str = "";
            try
            {
                str = File.ReadAllText(filePath);
                string[] sentences = str.Split('\n');
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to load file.");
                if (e is FormatException)
                {
                    Console.WriteLine("Wrong format.");
                }
                else if (e is FileNotFoundException)
                {
                    Console.WriteLine("File not found.");
                }
                if (e is PathTooLongException)
                {
                    Console.WriteLine("{0} is invalid file path.", filePath);
                }
                else if (e is DirectoryNotFoundException)
                {
                    Console.WriteLine("{0}: no such directory exists.");
                }
                else if (e is UnauthorizedAccessException)
                {
                    Console.WriteLine("{0}: No authorization for access.");
                }
            }

            return str;
        }

        //Gets a string from user which contains numbers delimited by spaces. Verifies if numbers can be converrted to int[]. Returns value to user or empty string if invalid input)
        public string GetKeyboardInput()
        {
            bool exit = false;
            Console.WriteLine("Please enter a sequence of numbers delimited by space, and press (\"Enter\").");
            string input = "";

            while (!exit)
            {
                try
                {
                    input = Console.ReadLine();
                    exit = true;
                }
                catch (Exception exception)
                {
                    if (exception is ArgumentNullException || exception is ArgumentException || exception is NullReferenceException)
                    {
                        Console.WriteLine("Error. String cannot be null or empty. Try again.");
                    }
                }

            }

            return input.Trim();
        }

        //Save string value to file. Return true if succeed, false if failed
        public bool WriteFile(string filePath, string str)
        {
            try
            {
                File.WriteAllText(filePath, str);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to save file.");

                if (e is PathTooLongException)
                {
                    Console.WriteLine("{0} is invalid file path.", filePath);
                }
                else if (e is DirectoryNotFoundException)
                {
                    Console.WriteLine("{0}: no such directory exists.");
                }
                else if (e is UnauthorizedAccessException)
                {
                    Console.WriteLine("{0}: No authorization for access.");
                }
                return false;
            }
            return true;
        }

        public abstract string FilterIntegerValues(string str);
        public abstract void GenerateRandomValues(string str);
    }
}
