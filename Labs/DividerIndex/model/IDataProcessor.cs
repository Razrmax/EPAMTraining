using System;
using System.Collections.Generic;
using System.Text;

namespace DividerIndex.model
{
    interface IDataProcessor
    {
        string ReadFile(string filePath, out int n, out int divider);
        bool WriteFile(string filePath, string str);
        string GetKeyboardInput();
        string GenerateRandomValues(int n);
    }
}
