using System;
using System.IO;
using ThermaCore.Application.Interfaces.System;

namespace ThermaCore.Infrastructure.Services.System;

public class LayoutService : ILayoutService
{
    private readonly string _layoutDirectory;

    public LayoutService()
    {
        var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        _layoutDirectory = Path.Combine(appData, "ThermaCore", "Layouts");
        
        if (!Directory.Exists(_layoutDirectory))
        {
            Directory.CreateDirectory(_layoutDirectory);
        }
    }

    public void SaveLayout(long kullaniciId, string formAdi, string kontrolAdi, string xmlData)
    {
        try
        {
            var fileName = GetFileName(kullaniciId, formAdi, kontrolAdi);
            var filePath = Path.Combine(_layoutDirectory, fileName);
            File.WriteAllText(filePath, xmlData);
        }
        catch
        {
            // Logging can be added here
        }
    }

    public string GetLayout(long kullaniciId, string formAdi, string kontrolAdi)
    {
        try
        {
            var fileName = GetFileName(kullaniciId, formAdi, kontrolAdi);
            var filePath = Path.Combine(_layoutDirectory, fileName);

            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
        }
        catch
        {
            // Logging can be added here
        }

        return string.Empty; // Return empty if not found
    }

    private string GetFileName(long kullaniciId, string formAdi, string kontrolAdi)
    {
        // Example: 1_SirketListForm_myGridView1.xml
        return $"{kullaniciId}_{formAdi}_{kontrolAdi}.xml";
    }
}
