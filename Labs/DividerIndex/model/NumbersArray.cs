using System;
using System.Collections.Generic;

namespace DividerIndex.model
{
    /// <summary>
    /// Stores N (as elementsNumber), C (as dividend), and int array of dividers. Calculates and reof a Dividend by their indices.
    /// </summary>
    class NumbersArray
    {
        public int ElementsNumber { get; }
        public int Dividend { get; }
        public int[] RawValues { get; }
        public NumbersArray(int elementsNumber, int dividend, int[] rawValues)
        {
            ElementsNumber = elementsNumber;
            Dividend = dividend;
            RawValues = rawValues;
        }
        /// <summary>
        /// Takes the string of numeric values (Rawvalues) and stores all the elements whose indices can be the dividers for the Dividend. Returns dividers as a string.
        /// </summary>
        /// <returns></returns>
        public string GetDividers()
        {
            List<int> dividers = new List<int>();
            try
            {
                for (int i = 1; i < RawValues.Length; i++)
                {
                    if (Dividend % i == 0)
                    {
                        dividers.Add(RawValues[i]);
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Values file empty");
                return "";
            }

            return string.Join("\n", dividers);
        }
    }
}
