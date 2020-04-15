using System.Collections.Generic;
using InterfaceTranslator.exceptions;

namespace InterfaceTranslator.model
{
    class TranslationMemory : ITermsChecker
    {
        public string LanguagePair { get; }
        protected Dictionary<string, string> translations;

        public TranslationMemory(string languagePair)
        {
            LanguagePair = languagePair;
        }
        /// <summary>
        /// Gets target string value from a translations if it exists. Throws TermNotFoundException if it does not and returns null.
        /// </summary>
        /// <param name="source">Source word</param>
        /// <returns>Target word</returns>
        public string GetTranslation(string source)
        {
            string target = "";
            try
            {
                VerifyTranslationExists(source);
                target = translations.GetValueOrDefault(source);
            }
            catch (TermNotFoundException)
            {
            }

            return target;
        }
        /// <summary>
        /// Adds a translation unit into the translation memory
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool AddTranslation(string source, string target)
        {
            if (!VerifyTranslationExists(source))
            {
                translations.Add(source, target);
                return true;
            }

            return false;
        }
        /// <summary>
        /// Verifies that the term actually exists and returns true if exists, throws TermNotFoundException if does not.
        /// </summary>
        /// <returns></returns>
        public bool VerifyTranslationExists(string term)
        {
            if (!translations.ContainsKey(term))
            {
                throw new TermNotFoundException(term);
            }

            return true;
        }
    }
}
