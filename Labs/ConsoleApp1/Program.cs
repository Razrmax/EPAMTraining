using System;

namespace ConsoleApp1
{
    class Program
    {
        static int a = 0;

        static int Foo()
        {
            a += 2;
            return 1;
        }
        static void Main()
        {
            a =                 Foo();
            Console.WriteLine(a);
        }
    }
}
