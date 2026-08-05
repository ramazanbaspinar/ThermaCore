using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        // Must register encoding provider for CodePages in .NET Core / .NET 5+
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        string[] filesToFix = new string[]
        {
            @"c:\Users\User\source\repos\ThermaCore\WinBeyazEsya.Presentation.WinForms\Forms\BaseForms\BaseListForm.Designer.cs",
            @"c:\Users\User\source\repos\ThermaCore\WinBeyazEsya.Presentation.WinForms\Forms\CodeTemplateForms\CodeTemplateEditForm.Designer.cs",
            @"c:\Users\User\source\repos\ThermaCore\WinBeyazEsya.Presentation.WinForms\Forms\CodeTemplateForms\CodeTemplateListForm.Designer.cs"
        };

        Encoding utf8 = Encoding.UTF8;
        Encoding win1254 = Encoding.GetEncoding(1254);
        Encoding utf8WithBom = new UTF8Encoding(true);

        foreach (string file in filesToFix)
        {
            if (File.Exists(file))
            {
                // Read the double-encoded UTF-8 file
                string content = File.ReadAllText(file, utf8);
                
                // Convert string back to bytes using Windows-1254
                byte[] ansiBytes = win1254.GetBytes(content);
                
                // Decode the bytes back to a string using UTF-8
                string fixedContent = utf8.GetString(ansiBytes);
                
                // Write back with proper UTF-8 BOM
                File.WriteAllText(file, fixedContent, utf8WithBom);
                Console.WriteLine("Reversed Mojibake in: " + file);
            }
            else
            {
                Console.WriteLine("File not found: " + file);
            }
        }
    }
}
