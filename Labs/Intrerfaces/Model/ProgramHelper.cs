namespace Interfaces.Model

{
    class ProgramHelper : ProgramConverter, ICodeChecker
        {
        public bool CheckCodeSyntax(string code, string language)
        {
            return true;
        }

        public string ConvertToCSharp(string str)
        {
            return "";
        }

        public string ConvertToVB(string str)
        {
            return "";
        }
    }
}
