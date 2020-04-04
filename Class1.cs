using System;

public class Class1
{
	public Class1()
	{
        int a = 0;

        int Foo()
        {
            a += 2;
            return 1;
        }
        void Main()
        {
            a += Foo();
            Console.WriteLine(a);
        }
	}
}
