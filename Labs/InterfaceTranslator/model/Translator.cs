using System.Text.RegularExpressions;

namespace InterfaceTranslator.model
{
    class Translator : ITranslatable
    {
        private readonly Vocabulary _rusEngVocabulary;
        private readonly Vocabulary _engRusVocabulary;

        public Translator()
        {
            _engRusVocabulary = new Vocabulary("EN-RU");
            _rusEngVocabulary = new Vocabulary("RU-EN");
        }
        /// <summary>
        /// Translates a string from source to target language. If source is Cyrillic, translates from Russian to English, and translates from English to Russian otherwise
        /// </summary>
        /// <param name="sourceText">source text (either Cyrillic or Latin)</param>
        /// <returns>target translation</returns>
        public string Translate(string sourceText)
        {
            string targetText = "Source cannot be empty!";
            if (sourceText != "")
            {
                string[] sourceWords = sourceText.Split(" ");
                targetText = "";
                Vocabulary currentVocabulary = IsCyrillicText(sourceText) ? _rusEngVocabulary : _engRusVocabulary;


                foreach (string word in sourceWords)
                {
                    targetText += currentVocabulary.Translate(word) + " ";
                }

                return targetText;
            }

            return targetText;
        }

        /// <summary>
        /// Checks that the whole sentence is Cyrillic and returns true if yes, false if at less one character is non-Cyrillic
        /// </summary>
        /// <param name="sentence">input string to be checked</param>
        /// <returns>true if all characters are Cyrillic, false otherwise </returns>
        public static bool IsCyrillicText(string str)
        {
            if (!Regex.IsMatch(str.Replace(" ", string.Empty), @"\P{IsCyrillic}"))
            {
                return true;
            }

            return false;
        }
    }
}
