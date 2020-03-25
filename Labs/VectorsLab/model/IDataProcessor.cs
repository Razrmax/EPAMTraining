namespace VectorsLab.model
{
    interface IDataProcessor
    {
        string ReadFile(string filePath);
        bool WriteFile(string filePath, string str);
        string GetKeyboardInput();
    }
}
