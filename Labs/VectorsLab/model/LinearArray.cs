using System;

namespace VectorsLab.model
{
    class LinearArray : AbstractLinearArray
    {
        public override void GenerateRandomValues(string str)
        {
            Random rand = new Random();
            int length = (rand.Next(10, 20));
            str = "";

            for (int i = 0; i < length; i++)
            {
                int randomValue = rand.Next(-100, 100);
                str += randomValue + " ";
            }

            str.Trim();
        }

        //Filter integer values from the input array. Save to Outlet.out
        public override string FilterIntegerValues(string str)
        {
            try
            {
                int[] values = Array.ConvertAll(str.Trim().Split(" "), int.Parse);
                if (values.Length < 2)
                {
                    str = "-1";
                }
                else
                {
                    int smallest = values[0], greatest = smallest;

                    foreach (int n in values)
                    {
                        if (smallest > n)
                        {
                            smallest = n;
                        }
                        if (greatest < n)
                        {
                            greatest = n;
                        }
                    }

                    if (smallest == greatest)                           //Only one value in array 
                    {
                        str = "-1";
                    }

                    else
                    {
                        str = "";
                        foreach (int n in values)
                        {
                            if (n > smallest && n < greatest)
                            {
                                str = str + n + "\n";
                            }
                        }

                        if (str == "")                                  //No values between min and max value
                        {
                            str = "-1";
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
    }
}
