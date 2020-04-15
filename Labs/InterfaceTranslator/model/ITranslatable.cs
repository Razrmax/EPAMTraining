namespace InterfaceTranslator.model
{
    interface ITranslatable
    {
        string Translate(string sentence);
        bool IsCyrillicText(string str);
    }
}
