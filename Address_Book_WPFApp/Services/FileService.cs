using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_WPFApp.Services;

internal class FileService
{
    private string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Contacts_WPFApp.json";
    public string LoadFile()
    {
        try
        {
            using var sr = new StreamReader(filePath);
            return sr.ReadToEnd();
        }
        catch { return null!; }
    }
    public void SaveFile(string content)
    {
        using var sw = new StreamWriter(filePath);
        sw.WriteLine(content);
    }
}
