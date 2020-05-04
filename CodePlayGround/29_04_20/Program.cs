using System;
using System.IO;

namespace _29_04_20
{

    class Program
    {
        public static void Main()
        {
            Deligates d = new Deligates();

        }
    }

    class Deligates
    {
        delegate void Anonim();

        Anonim anonim = delegate
        {
            DirectoryInfo d = new DirectoryInfo("C:\\");
            foreach (var v in d.GetDirectories())
            {
                Console.WriteLine(v);
            }
        };
    }
}
