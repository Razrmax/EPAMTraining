using System;

namespace EPAMTraining
{
    class MonotonicValues
    {
        static void Main()
        {
            Console.WriteLine("Enter x: ");
            double x = GetNumberInput();
            Console.WriteLine("Enter approximation (eps): ");
            double eps = GetNumberInput();
            double totalSum = CalcTotalSum(x, eps);
            Console.WriteLine("The sum of a series of numbers where x = {0} and approximation is {1:N4} equals: {2:N4}", x, eps, totalSum);
            Console.ReadKey();
        }

        static double CalcTotalSum(double x, double eps)
        {
            double totalSum = 0;
            int n = 0;
            double divider = 1;                                             // divider (2n+1)! - a factorial
            do
            {
                divider *= (2 * n + 1);

                double element = Math.Pow(-1, n) * (Math.Pow(x, 2 * n++ + 1) / divider);
                if (Math.Abs(element) < eps)
                {
                    break;
                }
                totalSum += element;
            } while (true);

            return totalSum;
        }

        static double GetNumberInput()
        {
            do
            {
                try
                {
                    double number = Convert.ToDouble(Console.ReadLine());
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
