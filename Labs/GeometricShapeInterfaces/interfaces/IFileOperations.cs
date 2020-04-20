namespace GeometricShapeInterfaces.interfaces
{
    interface IFileOperations
    {
        void SaveToFile(string fileName);
        bool LoadFromFile(string fileName);
    }
}
