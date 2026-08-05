using System.Threading.Tasks;
using WinBeyazEsya.Application.Interfaces.System;

namespace WinBeyazEsya.Application.Services.System;

public class SessionManager : ISessionService
{
    public async Task StartSessionAsync(long kullaniciId, string ip, string pcName)
    {
        // Session başlatma mantığı
        await Task.CompletedTask;
    }

    public async Task EndSessionAsync(long kullaniciId)
    {
        // Session sonlandırma mantığı
        await Task.CompletedTask;
    }
}

