using System;
using System.IO;
using System.Text.Json;
using WinBeyazEsya.Application.Interfaces.Configuration;
using WinBeyazEsya.Application.Interfaces.Security;
using WinBeyazEsya.Infrastructure.Security;

namespace WinBeyazEsya.Infrastructure.Configuration;

public class AppConfigService : IAppConfigService
{
    private readonly string _settingsPath;
    private readonly ICryptoService _cryptoService;

    public AppConfigService() : this(new CryptoService())
    {
    }

    public AppConfigService(ICryptoService cryptoService)
    {
        _cryptoService = cryptoService;
        string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string folder = Path.Combine(appData, "WinBeyazEsya");
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
        string encrypted = LoadSettings().ConnectionString;
        if (string.IsNullOrEmpty(encrypted))
            return string.Empty;

        try
        {
            return _cryptoService.Decrypt(encrypted);
        }
        catch
        {
            // Deşifre edilemezse (örneğin önceden şifresiz kaydedilmişse) düz metin olarak döner
            return encrypted;
        }
    }

    public void SetConnectionString(string connectionString)
    {
        var settings = LoadSettings();
        settings.ConnectionString = _cryptoService.Encrypt(connectionString);
        SaveSettings(settings);
    }

    public long GetLastTenantId()
    {
        return LoadSettings().LastTenantId;
    }

    public void SetLastTenantId(long tenantId)
    {
        var settings = LoadSettings();
        settings.LastTenantId = tenantId;
        SaveSettings(settings);
    }

    public long GetLastBranchId()
    {
        return LoadSettings().LastBranchId;
    }

    public void SetLastBranchId(long branchId)
    {
        var settings = LoadSettings();
        settings.LastBranchId = branchId;
        SaveSettings(settings);
    }

    private class SettingsModel
    {
        public string LastLoginUser { get; set; } = string.Empty;
        public long LastTenantId { get; set; } = 0;
        public long LastBranchId { get; set; } = 0;
        public string ConnectionString { get; set; } = string.Empty;
    }
}

