using System;
using System.Linq;

namespace VectorsLab.model
{
    class LinearArray : AbstractLinearArray
    {
        public override string GenerateRandomValues(string str)
        {
            Random rand = new Random();
            int length = 5;
            str = "";

            for (int i = 0; i < length; i++)
            {
                int randomValue = rand.Next(0, 5);
                str += randomValue + " ";
            }

            return str.Trim();
        }
        //Copy integer values from the array to the string as follows:
        //1) Copy from the array all the values whose indices are located in between the marginal MIN and MAX values of the array
        //2) If there are more then 2 min values in the array, copy all values in between the marginal leftmost and rightmost MIN values excluding MAX value.
        //3) Return a string representation of resulting values with \n between them
        public override string CopyBetweenMinMaxValues(string str)
        {
            try
            {
                int[] values = Array.ConvertAll(str.Trim().Split(" "), int.Parse);
                str = "";
                if (values.Length < 3)
                {
                    str = "Not enough arguments. At less 3 distinct integers needed.";
                }
                else
                {
                    int minValue = values.Min();
                    int maxValue = values.Max();
                    if (minValue == maxValue)
                    {
                        str = "-1";
                    }
                    else
                    {
                        int minLeftIndex = Array.IndexOf(values, minValue);
                        int maxLeftIndex = Array.IndexOf(values, maxValue);
                        int minRightIndex = Array.LastIndexOf(values, minValue);
                        int maxRightIndex = Array.LastIndexOf(values, maxValue);
                        int leftIndex = 0;
                        int rightIndex = 0;
                        int middleIndex = 0;

                        if (minLeftIndex < maxLeftIndex)
                        {
                            leftIndex = minLeftIndex;
                            if (minRightIndex > maxRightIndex)
                            {
                                rightIndex = minRightIndex;
                            }
                            else
                            {
                                rightIndex = maxRightIndex;
                            }
                        }
                        else
                        {
                            leftIndex = maxLeftIndex;
                            rightIndex = minRightIndex;
                        }

                        //int rightIndex = Array.LastIndexOf(values, minValue);
                        //int leftIndex = Array.IndexOf(values,minValue);
                        //int maxValueIndex = Array.LastIndexOf(values, maxValue);


                        //if(maxValueIndex < leftIndex)
                        //{
                        //    leftIndex = Array.IndexOf(values, maxValue);
                        //    maxValueIndex = rightIndex;
                        //}
                        //else if (maxValueIndex > rightIndex)
                        //{
                        //    rightIndex = maxValueIndex;
                        //}

                        leftIndex++;

                        for (int i = leftIndex; i < rightIndex; i++)
                        {
                            if (i == rightIndex - 1)
                            {
                                str += values[i];
                            }
                            else
                            {
                                str += values[i] + "\n";
                            }
                        }

                        if (str == "")
                        {
                            str = "-1";
                        }
                    }
                }
            }
            catch (FormatException)
            {
                str = "No valid values found in file";
            }

            return str;
        }
        //True if the array contains duplicate values, false otherwise
        private bool ContainsDuplicates(int[] values, int key)
        {
            int counter = 0;
            foreach (int i in values)
            {
                if (i == key)
                {
                    counter++;
                }
            }
            return counter >= 2;
        }
    }
}
