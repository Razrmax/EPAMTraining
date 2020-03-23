using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace VectorsLab.model
{
    class LinearArray
    {
        int[] filteredValues;

        public LinearArray()
        { 
        }

        public LinearArray(int[] filteredValues)
        {
            this.filteredValues = filteredValues;
        }

        public string ReadFile()
        {
            string[] str = File.ReadAllText("Inlet.in").Split(" ");
            filteredValues = Array.ConvertAll<string,int>(str,s => int.Parse)
            filteredValues = str.Length;
        }
    }
}
