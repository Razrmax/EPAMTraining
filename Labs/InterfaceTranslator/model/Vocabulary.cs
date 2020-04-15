using System.Collections.Generic;
using System.IO;

namespace InterfaceTranslator.model
{
    class Vocabulary : TranslationMemory, ITermsGenerator
    {

        public Vocabulary(string languagePair) : base(languagePair)
        {
            GenerateSpecificDictionary();
        }
        /// <summary>
        /// Generates a translations. Reads English and Russian words files and stores values in a translations.
        /// </summary>
        public void GenerateSpecificDictionary()
        {
            string[] sourceWords;
            string[] targetWords;

            if (LanguagePair == "EN-RU")
            {
                sourceWords =
                    File.ReadAllLines(
                        @"C:\Users\Maxim\Desktop\Programming\EPAMTraining\Labs\InterfaceTranslator\storage\ENG Voc.txt");
                targetWords =
                    File.ReadAllLines(
                        @"C:\Users\Maxim\Desktop\Programming\EPAMTraining\Labs\InterfaceTranslator\storage\RUS Voc.txt");
            }
            else
            {
                sourceWords =
                    File.ReadAllLines(
                        @"C:\Users\Maxim\Desktop\Programming\EPAMTraining\Labs\InterfaceTranslator\storage\RUS Voc.txt");
                targetWords =
                    File.ReadAllLines(
                        @"C:\Users\Maxim\Desktop\Programming\EPAMTraining\Labs\InterfaceTranslator\storage\ENG Voc.txt");
            }

            translations = new Dictionary<string, string>();

            for (int i = 0; i < sourceWords.Length; i++)
            {
                if (!translations.ContainsKey(sourceWords[i]))
                {
                    translations.Add(sourceWords[i], targetWords[i]);
                }
            }
        }
    }
}
