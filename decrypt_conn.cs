using System;
using System.IO;
using WinBeyazEsya.Infrastructure.Security;

class Program
{
    static void Main()
    {
        var crypto = new CryptoService();
        var content = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WinBeyazEsya", "settings.json"));
        var obj = System.Text.Json.JsonDocument.Parse(content);
        var encrypted = obj.RootElement.GetProperty("ConnectionString").GetString();
        Console.WriteLine("Master Connection String: " + crypto.Decrypt(encrypted));
    }
}
