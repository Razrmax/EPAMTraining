using System;

namespace EPAMTraining.Pluralsight.MSIL
{
    class Class
    {
        static void Main()
        {
            int a = 2, b = 1;
            System.Console.WriteLine(Calculate(a, b));
            Console.ReadLine();

        }
        static int Calculate(int a, int b)
        {
            return a + b;
        }
    }
}


