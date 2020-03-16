using System;

/* Write the program calculating the Sum including the first k: Доработать по рекурентному 
          k      cos(Pi/4)
    S = E Sum    --------- * x^n
         n = 0      n!
    */
namespace EPAMTraining
{
    class ArithmeticCycles
    {
        static void Main()
        {
            int[] inputValues = new int[2];                                             //An array to store k[0th element] and x[1st element]
            Console.WriteLine("Calculator for  the sum of the sequence of numbers from n=0 to k made on formula\n " +
                "    k        cos(Pi/4)\nS = E Sum    --------- * x^n\n     n = 0      n!\n\n");
            Console.WriteLine("Please enter a whole number for k and x: ");
            for (int i = 0; i < inputValues.Length; i++)
            {
                inputValues[i] = GetNumberInput();
            }
            int k = inputValues[0];
            int x = inputValues[1];

            double totalSum = CalcTotalSum(k, x);
            Console.WriteLine("Result: {0:N4}", totalSum);
            Console.ReadLine();
        }

        //Get numbers from the user
        static int GetNumberInput()
        {
            do
            {
                try
                {
                    int number = Convert.ToInt32(Console.ReadLine());
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

        //Calculate the Total Sum of the whole Equation based on formula
        private static double CalcTotalSum(int k, int x)
        {
            double totalSum = 0;
            double divider = 1;
            double multiplier = x;
            for (int n = 0; n < k; n++)
            {
                if (n == 0)
                {
                    multiplier = 1;
                }
                if (n > 1)
                {
                    divider *= n;
                    multiplier *= multiplier;
                }

                totalSum += (Math.Cos(Math.PI / 4) / x * multiplier);
            }
            return totalSum;
        }
    }
}
