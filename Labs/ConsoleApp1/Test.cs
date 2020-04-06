using System;
using System.IO;

namespace ConsoleApp1
{
    class Test
    {
        static void Main()
        {
            string filePath = @"C:\...\...\test.txt";
            try
            {
                string str = File.ReadAllText(filePath);
                try
                {
                    double[] coords = Array.ConvertAll(str.Split(", "), Double.Parse);
                    if (coords.Length % 2 == 0)
                    {
                        for (int i = 0; i < coords.Length; i += 2)
                        {
                            Console.WriteLine("X: {0} Y:{1}", coords[i], coords[i + 1]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong input, must be paired numbers!");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error reading file: " + filePath);
            }
        }
    }
}
