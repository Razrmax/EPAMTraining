namespace Interfaces.Model
{
    interface IConvertible
    {
        string ConvertToCSharp(string str);
        string ConvertToVB(string str);
    }
}
