using System;

namespace BinaryConverter
{
    class Program
    {
        static void Main()
        {
            Console.Write("Please enter any positive whole number: ");
            int number = GetNumberInput();
            string binaryString = ConvertDecimalToBinary(number);
            string customBinaryString = CustomConvertDecimalToBinary(number);
            Console.WriteLine(".NET embedded binary representation of {0}: {1}", number, binaryString);
            Console.WriteLine("Custom implemented representation of {0}: {1}", number, binaryString);
            Console.ReadLine();
        }

        static string CustomConvertDecimalToBinary(int number)
        {
            int length = CountBits(number);
            char[] bitMask = new char[length];
            for (int i = length - 1; i >= 0; i--)
            {
                bitMask[i] = (number % 2 == 0) ? '0' : '1';
                number /= 2;
            }
            string binary = new string(bitMask);

            return binary;
        }

        static int CountBits(int number)
        {
            return (int)Math.Log(number, 2.0) + 1;
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
