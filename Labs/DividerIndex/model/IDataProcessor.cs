using System;
using System.Collections.Generic;
using System.Text;

namespace DividerIndex.model
{
    interface IDataProcessor
    {
        string ReadFile(string filePath);
        bool WriteFile(string filePath, string str);
        string GetKeyboardInput();
        string GenerateRandomValues(int n);
    }
}
