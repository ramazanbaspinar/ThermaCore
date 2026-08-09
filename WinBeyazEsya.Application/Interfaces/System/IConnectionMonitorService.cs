using System.Threading.Tasks;

namespace WinBeyazEsya.Application.Interfaces.System;

public interface IConnectionMonitorService
{
    Task<bool> CheckConnectionAsync();
}
