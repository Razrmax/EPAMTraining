using System;

namespace QuotientCalculator
{
    class Program
    {
        static void Main()
        {
            int[] numbers = new int[2];
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine("Please enter a whole number: ");
                numbers[i] = GetNumberInput();
            }
            Console.WriteLine("The quotient of {0} divided by {1} equals {2:N2}", numbers[0], numbers[1], CalcQuotient(numbers));
            Console.ReadLine();
        }

        //Getting input from a user, if equals 0 - continue to avoid division of and by 0
        //Also processing overflow and wrong number formats
        static int GetNumberInput()
        {
            do
            {
                try
                {
                    int number = Convert.ToInt32(Console.ReadLine());
                    if (number == 0)
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

        static double CalcQuotient(int[] numbers)
        {
            double result = (double)numbers[0] / numbers[1];
            return result;
        }
    }
}
