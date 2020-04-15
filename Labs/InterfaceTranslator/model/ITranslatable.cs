using System.Text.RegularExpressions;

namespace InterfaceTranslator.model
{
    interface ITranslatable
    {
        string Translate(string sentence);
        
    }
}
