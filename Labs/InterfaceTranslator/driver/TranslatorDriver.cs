using InterfaceTranslator.model;
using System;

namespace InterfaceTranslator.driver
{
    class TranslatorDriver
    {
        static void Main()
        {
            TranslationMemory engRusTM = new TranslationMemory("EN-RU");
            TranslationMemory rusEngTM = new TranslationMemory("RU-EN");

            Translator translator = new Translator();
            bool exit = false;

            while (!exit)
            {
                string source = Console.ReadLine();

                if (source != "_exit")
                {
                    TranslationMemory currentTM = Translator.IsCyrillicText(source)
                        ? rusEngTM
                        : engRusTM;
                    if (currentTM.VerifyTranslationExists(source))
                    {
                        Console.WriteLine(currentTM.Translate(source));
                    }
                    else
                    {
                        string target = translator.Translate(source);
                        Console.WriteLine(target);
                        currentTM.AddTranslation(source, target);
                    }
                }

                else
                {
                    exit = true;
                }
            }
        }
    }
}
