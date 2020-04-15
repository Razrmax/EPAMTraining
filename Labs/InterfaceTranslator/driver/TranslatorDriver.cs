using System;
using InterfaceTranslator.model;

namespace InterfaceTranslator.driver
{
    class TranslatorDriver
    {
        static void Main()
        {
            Vocabulary engRusDictionary = new Vocabulary("EN-RU"); 
            Vocabulary rusEngDictionary = new Vocabulary("RU-EN");

            Translator translator = new Translator();
            string translatableText = Console.ReadLine();
            bool exit = false;

            while (!exit)
            {
                string source = Console.ReadLine();
                
                if (source != "_exit")
                {
                    Console.WriteLine(translator.Translate(source));
                }

                else
                {
                    exit = true;
                }
            }
        }
    }
}
