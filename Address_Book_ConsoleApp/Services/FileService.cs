using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_ConsoleApp.Services;

public class FileService
{
    public string FilePath { get; set; } = null!;
    public void Save(string content)
    {
        using var sw = new StreamWriter(FilePath);
        sw.WriteLine(content);
    }

    public string Read()
    {
        try
        {
            using var sr = new StreamReader(FilePath);
            return sr.ReadToEnd();
        }
        catch { return null! + "Could not load File..."; }
    }
}
