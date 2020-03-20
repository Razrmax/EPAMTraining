using System;
using System.Text;

namespace EPAMTraining
{
    public class TestRegularExpressions
    {
        static void Main()
        {
            string[] sentences = 
            {
                "cow vsdfv sfsf sdfg",
                "gfdg cow fgdsgs adfs",
                "fsdf vfvd cow fsfs",
                "sdfgsdf fwsfsd wfers cow"
            };

            string sPattern = "cow";

            foreach(string s in sentences)
            {
                System.Console.WriteLine("{0,24}", s);
                if(System.Text.RegularExpressions.Regex.IsMatch(s,sPattern,System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    System.Console.WriteLine("match for {0} found",sPattern);
                }
                else
                {
                    System.Console.WriteLine();
                }
            }
        }
    }
}