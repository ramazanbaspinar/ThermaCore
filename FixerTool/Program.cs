using System;
using System.IO;
using System.Text;
using System.Linq;

class Program
{
    static void Main()
    {
        var replacements = new System.Collections.Generic.Dictionary<string, string>
        {
            { "Ã¼", "ü" },
            { "Ä±", "ı" },
            { "ÄŸ", "ğ" },
            { "Ã§", "ç" },
            { "ÅŸ", "ş" },
            { "Ã¶", "ö" },
            { "Ãœ", "Ü" },
            { "Ä°", "İ" },
            { "Äž", "Ğ" },
            { "Ã‡", "Ç" },
            { "Åž", "Ş" },
            { "Ã–", "Ö" }
        };

        var root = @"c:\Users\User\source\repos\ThermaCore";
        var files = Directory.EnumerateFiles(root, "*.*", SearchOption.AllDirectories)
                             .Where(s => s.EndsWith(".cs") || s.EndsWith(".resx") || s.EndsWith(".json"))
                             .ToList();

        var utf8Bom = new UTF8Encoding(true);

        foreach (var file in files)
        {
            var content = File.ReadAllText(file, Encoding.UTF8);
            bool modified = false;

            foreach (var kvp in replacements)
            {
                if (content.Contains(kvp.Key))
                {
                    content = content.Replace(kvp.Key, kvp.Value);
                    modified = true;
                }
            }

            if (modified)
            {
                Console.WriteLine($"Modified: {file}");
                File.WriteAllText(file, content, utf8Bom);
            }
        }
    }
}
