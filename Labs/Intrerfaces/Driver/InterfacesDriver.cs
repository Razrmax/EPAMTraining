using Interfaces.Model;
using System;

namespace Interfaces.Driver
{
    class InterfacesDriver
    {
        static void Main()
        {
            ProgramConverter[] converters = ProgramConverterGenerator(10);


            for (int i = 0; i < converters.Length; i++)
            {
                if (converters[i] is ICodeChecker)
                {
                    ProgramHelper programHelper = converters[i] as ProgramHelper;
                    Console.WriteLine("Code check complete: " + programHelper.CheckCodeSyntax("dim next", "vb"));
                    Console.WriteLine("Converting to C#. Before conversion: var a");
                    Console.WriteLine("After conversion: " + programHelper.ConvertToCSharp("var a"));
                    Console.WriteLine("Converting to VB. Before conversion: int a");
                    Console.WriteLine("After conversion: " + programHelper.ConvertToCSharp("int a"));

                }

                else
                {
                    Console.WriteLine("Converting to C#. Before conversion: var a");
                    System.Console.WriteLine(converters[i].ConvertToCSharp("var a"));
                    Console.WriteLine("Converting to VB. Before conversion: int a");
                    System.Console.WriteLine(converters[i].ConvertToVB("int a"));
                }
            }
        }

        static ProgramConverter[] ProgramConverterGenerator(int length)
        {
            ProgramConverter[] programConverters = new ProgramConverter[length];

            for (int i = 0; i < length; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    programConverters[i] = new ProgramHelper();
                }
                else
                {
                    programConverters[i] = new ProgramConverter();
                }
            }

            return programConverters;
        }
    }
}
