using System;
using System.IO;
using System.Linq;

namespace StringsLab
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence;
            bool isContinue = true;

            while (isContinue)
            {
                Console.WriteLine("1) Read value from Inlet.in\t\t\t2) Input value from keyboard\nANy other key to quit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        sentence = ReadFile();
                        sentence = FilterSentence(sentence);
                        DisplayResult(sentence);
                        continue;

                    case "2":
                        sentence = GetUserInput();
                        sentence = FilterSentence(sentence);
                        DisplayResult(sentence);
                        continue;

                    default:
                        isContinue = false;
                        break;
                }
            }
        }

        static string GetUserInput()
        {
            while (true)
            {
                Console.WriteLine("Enter string: ");
                string str = Console.ReadLine();
                bool isValid = isWord(str);

                if (isValid)
                {
                    return str;
                }

                Console.WriteLine("Illegal value. Enter sentence only from words delimited with spaces.");
            }
        }

        static bool isWord(string word)
        {
            return word.All(c => char.IsWhiteSpace(c) || char.IsLetter(c));
        }

        static string FilterSentence(string sentence)
        {
            string filteredSentence = "";
            string[] words = sentence.Split(" ");
            string validSentence = "";

            foreach (string s in words)
            {
                char[] characters = s.ToCharArray();
                bool isValidWord = false;

                int charCounter = 0;

                for (int i = 0; i < characters.Length; i++)
                {
                    int occurence = 1;
                    char currentChar = characters[i];

                    foreach (char ch in characters)
                    {
                        if (ch == currentChar)
                        {
                            continue;
                        }
                        else
                        {
                            occurence++;
                        }

                    }

                    if (occurence >= 2)
                    {
                        isValidWord = true;
                        break;
                    }
                }

                if (isValidWord)
                {
                    validSentence = validSentence + s + " ";
                }
            }

            return validSentence;
        }
        static private string ReadFile()
        {
            try
            {
                string contents = File.ReadAllText("Inlet.in");
                return contents;
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("File not found");
                return "invalidx";
            }

        }

        static void DisplayResult(string sentence)
        {
            Console.WriteLine("Filtered value, every word contains at less 2 same chars: ");
            Console.WriteLine(sentence);
        }
    }
}
