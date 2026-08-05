using System.Threading.Tasks;

namespace WinBeyazEsya.Application.Interfaces.System;

public interface ISessionService
{
    Task StartSessionAsync(long kullaniciId, string ip, string pcName);
    Task EndSessionAsync(long kullaniciId);
}

