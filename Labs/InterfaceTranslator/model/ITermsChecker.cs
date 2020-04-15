namespace InterfaceTranslator.model
{
    interface ITermsChecker
    {
        string GetTranslation(string source);
        bool VerifyTranslationExists(string term);
    }
}
