using System;
/* Лабораторная работа по теме "Итерационные циклы", ВАРИАНТ: 4
 * Найти корень уравнения на отрезке [a(1.2); b(2)] с точностью " указанным в варианте методом и способом контроля - */

namespace EPAMTraining
{
    class IterationCycles
    {

        static void Main()
        {

            double a = 1.2;
            double b = 2;

            Console.WriteLine("Please enter the eps value (0 < eps < 0.8): ");
            double eps = GetNumberInput();
            double x = SolveEquation(a, b, eps);
            double funcResult = Func(x);
            Console.WriteLine("X equals: {0:N4}\nFunction: {1:N4}", x, funcResult);
            Console.ReadLine();
        }


        static double GetNumberInput()
        {
            do
            {
                try
                {
                    double number = Convert.ToDouble(Console.ReadLine());
                    if (number > 0 && number < 0.8)
                    {
                        return number;
                    }
                    Console.WriteLine("Number out of range. Try again:");
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

        static double Func(double x)
        {
            return x - 2 * Math.Sin(1 / x);
        }

        static double SolveEquation(double a, double b, double eps)
        {
            while ((b - a) > eps)
            {
                double c = (b + a) / 2;
                if (Func(c) == 0)
                {
                    return Func(c);
                }
                if (Func(a) * Func(c) < 0)
                {
                    b = c;
                }
                else
                {
                    a = c;
                }
            }

            return (a + b) / 2;
        }
    }
}
