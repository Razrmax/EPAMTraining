
namespace Interfaces.Model

{
    class ProgramConverter : Model.IConvertible
    {
        public string ConvertToCSharp(string str)
        {

            if (str.Contains("var"))
            {
                str = str.Replace("var", "int");
            }

            return str;
        }

        public string ConvertToVB(string str)
        {
            if (str.Contains("int"))
            {
                str = str.Replace("int", "var");
            }

            return str;
        }
    }
}
