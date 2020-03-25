using System;
using System.IO;

namespace DividerIndex.model
{
    abstract class AbstractWordArray : IDataProcessor
    {
        //Reads specified string file, checks values and returns 1) string or 2) "" if file does not exist or contains illegal values.
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
        //Gets a string from user which contains n and c delimited by space.
        public void GetKeyboardInput(out int n, out int dividend)
        {
            bool exit = false;
            Console.WriteLine("Please enter n and C values delimited by space and press (\"Enter\"):");
            string input = "";

            while (!exit)
            {

                string s = Console.ReadLine();
                
                
            }

            return input.Trim();
        }
        //Generates reandom values (0 to 40) for int[1...n] and returns as string
        public string GenerateRandomValues(int n)
        {
            Random rand = new Random();
            string values = "";
            for (int i = 0; i < n; i++)
            {
                values += rand.Next(1, rand.Next(0, 40)) + " ";
            }

            return values.Trim();
        }
        public abstract string FindDividers(string str, int dividend);
    }
}
