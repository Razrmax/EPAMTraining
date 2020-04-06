using System;
using System.IO;

namespace DividerIndex.model
{
    /// <summary>
    /// Stores string values to ...Outlet.out. Loads values from ...Inlet.in.
    /// </summary>
    class FileManager
    {

        /// <summary>
        /// Reads specified string file, verifies that it contains the minimum required number of elements, and returns these elements as a string ("" if values are invalid).
        /// </summary>
        /// <param name="filePath">specified file path</param>
        /// <param name="dividend">minimum length of values to be returned. If less than minimum, return ""(C)</param>
        /// <returns></returns>
        public string ReadFile(string filePath, int minimumLength)
        {
            string str = "";
            try
            {
                str = File.ReadAllText(filePath);
                if (str.Length < minimumLength)
                {
                    str = "";
                }
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
                else
                {
                    ExceptionManager(e, filePath);
                }
            }
            return str;
        }
        /// <summary>
        /// Save string value to file. Return true if succeed, false if failed
        /// </summary>
        /// <param name="str">string value to be saved</param>
        /// <param name="filePath">specified file path</param>
        /// <returns></returns>
        public bool WriteFile(string str, int[] elements, string filePath)
        {
            string values = string.Join("\n", Array.ConvertAll(elements, n => n.ToString()));
            try
            {
                File.WriteAllText(filePath, str + values);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to save file.");
                ExceptionManager(e, filePath);
                return false;
            }
            return true;
        }

        public bool WriteFile(string str, string filePath)
        {
            try
            {
                File.WriteAllText(filePath, str);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to save file.");

                ExceptionManager(e, filePath);
                return false;
            }
            return true;
        }

        public void ExceptionManager(Exception e, string filePath)
        {
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

        public void ProcessInputFile(out int elementsNumber, out int dividend, string values, out int[] elements)
        {
            elementsNumber = 0;
            dividend = 0;
            elements = null;
            try
            {
                string[] temp = values.Split("\n");
                elements = Array.ConvertAll(temp[0].Split(" "), int.Parse);
                elementsNumber = elements[0];
                dividend = elements[1];
                elements = new int[elementsNumber];
                for (int i = 0; i < elementsNumber; i++)
                {
                    elements[i] = Convert.ToInt32(temp[i + 1]);
                }
            }
            catch (Exception e)
            {
                if (e is ArgumentNullException)
                {
                    Console.WriteLine("Wrong arguments passed.");
                }
                dividend = 0;
                elementsNumber = 0;
            }
        }
    }
}
