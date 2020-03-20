using System;

namespace EPAMTraining
{
    public class Strings
    {
        static void Main()
        {
            string s1 = "Cat ate tak and ran taf";
            string[] words = s1.Split(" ");

            foreach(string s in words)
            {
                System.Console.WriteLine(s);
            }             
        }
    }
}