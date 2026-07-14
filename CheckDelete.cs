using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string dir = @"c:\Users\User\source\repos\ThermaCore\ThermaCore.Presentation.WinForms\Forms\TanimlarForms";
        var files = Directory.GetFiles(dir, "*.cs", SearchOption.AllDirectories)
            .Where(f => f.EndsWith("ListForm.cs") || f.EndsWith("EditForm.cs"));

        foreach (var file in files)
        {
            var content = File.ReadAllText(file);
            bool hasDeleteMethod = content.Contains("protected override void EntityDelete");
            if (!hasDeleteMethod)
            {
                Console.WriteLine("MISSING METHOD: " + file);
                continue;
            }

            int startIndex = content.IndexOf("protected override void EntityDelete");
            int openBraces = 0;
            bool foundFirstBrace = false;
            int endIndex = startIndex;
            
            for (int i = startIndex; i < content.Length; i++)
            {
                if (content[i] == '{')
                {
                    openBraces++;
                    foundFirstBrace = true;
                }
                else if (content[i] == '}')
                {
                    openBraces--;
                }
                
                if (foundFirstBrace && openBraces == 0)
                {
                    endIndex = i;
                    break;
                }
            }

            string methodContent = content.Substring(startIndex, endIndex - startIndex + 1);
            
            bool hasConfirm = methodContent.Contains("SilMesaj") || methodContent.Contains("MessageBox.Show");
            if (!hasConfirm)
            {
                Console.WriteLine("MISSING CONFIRM: " + file);
            }

            if (file.EndsWith("EditForm.cs"))
            {
                if (!methodContent.Contains("Close()"))
                {
                    Console.WriteLine("MISSING CLOSE (EditForm): " + file);
                }
                if (!methodContent.Contains("RefreshYapilacak"))
                {
                    Console.WriteLine("MISSING REFRESH (EditForm): " + file);
                }
            }
        }
    }
}
