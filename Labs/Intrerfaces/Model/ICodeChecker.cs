namespace Interfaces.Model
{
    interface ICodeChecker
    {
        bool CheckCodeSyntax(string code, string language);
    }
}
