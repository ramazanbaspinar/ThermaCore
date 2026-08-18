using WinBeyazEsya.Application.DTOs.Updater;

namespace WinBeyazEsya.Application.Interfaces.Updater
{
    public interface IAutoUpdateService
    {
        Task<UpdateManifestDto> CheckForUpdatesAsync();
        Task<bool> DownloadUpdatesAsync(UpdateManifestDto manifest, string appPath);
        bool IsUpdateReady(string appPath, out UpdateManifestDto manifest);
        Task<string> GetUpdateServerUrlAsync();
    }
}

