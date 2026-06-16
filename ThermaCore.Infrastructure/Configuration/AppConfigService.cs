using System;
using System.IO;
using System.Text.Json;
using ThermaCore.Application.Interfaces.Configuration;

namespace ThermaCore.Infrastructure.Configuration;

public class AppConfigService : IAppConfigService
{
    private readonly string _settingsPath;

    public AppConfigService()
    {
        string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string folder = Path.Combine(appData, "ThermaCore");
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }
        _settingsPath = Path.Combine(folder, "settings.json");
    }

    private SettingsModel LoadSettings()
    {
        if (!File.Exists(_settingsPath))
            return new SettingsModel();
        
        string json = File.ReadAllText(_settingsPath);
        return JsonSerializer.Deserialize<SettingsModel>(json) ?? new SettingsModel();
    }

    private void SaveSettings(SettingsModel settings)
    {
        string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_settingsPath, json);
    }

    public string GetLastLoginUser()
    {
        return LoadSettings().LastLoginUser;
    }

    public void SetLastLoginUser(string username)
    {
        var settings = LoadSettings();
        settings.LastLoginUser = username;
        SaveSettings(settings);
    }

    public string GetConnectionString()
    {
        return LoadSettings().ConnectionString;
    }

    public void SetConnectionString(string connectionString)
    {
        // İleride şifreleme/çözme mekanizmaları eklenebilir
        var settings = LoadSettings();
        settings.ConnectionString = connectionString;
        SaveSettings(settings);
    }

    private class SettingsModel
    {
        public string LastLoginUser { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
    }
}
