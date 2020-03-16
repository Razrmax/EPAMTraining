using System;
using System.Collections.Generic;
using System.Text;

namespace EPAMTraining.Lab16_03_19
{
    class BinaryConverter
    {
        static void Main()
        {
            Console.WriteLine("Please enter any positive whole number: ");
            int number = GetNumberInput();
            string binaryString = ConvertDecimalToBinary(number);
            Console.WriteLine(binaryString);
            
        }

        static string ConvertDecimalToBinary(int number)
        {
            return Convert.ToString(number, 2);
        }

        static int GetNumberInput()
        {
            do
            {
                try
                {
                    int number = Convert.ToInt32(Console.ReadLine());
                    if (number < 0)
                    {
                        continue;
                    }
                    return number;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Number is too big! Please enter number in range between {1} and {2}.", Int32.MinValue, Int32.MaxValue);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong number format! Please try again: ");
                }
            } while (true);
        }
    }
}
