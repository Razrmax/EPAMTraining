using System;
using System.IO;
using DividerIndex.model;

namespace DividerIndex.model
{
    class NumbersArray : AbstractNumbersArray
    {
        //Filter words from the input file. Return filtered value, "" if input was invalid.
        public override string FindDividers(string str, int dividend)
        {
            try
            {
                int[] values = Array.ConvertAll(str.Trim().Split(" "), int.Parse);
                if (values.Length < 3)
                {
                    str = "";
                }
                else
                {
                    str = "";
                    for (int i = 2; i < values.Length; i++)
                    {
                        if (IsDivider(dividend, i))
                        {
                            str += values[i] + " ";
                        }
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Values file empty");
                str = "";
            }

            return str;
        }
        //Check that the string value is valid, i.e. contains at less two different literal values
        private bool IsDivider (int dividend, int divisor)
        {
            try
            {
                if (dividend % divisor == 0)
                {
                    return true;
                }
            }
            catch (DivideByZeroException)
            {
            }
            return false;
        }
    }
}
