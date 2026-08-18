using WinBeyazEsya.Application.Interfaces.System;
using WinBeyazEsya.Infrastructure.Persistence;

namespace WinBeyazEsya.Infrastructure.System;

public class ConnectionMonitorManager : IConnectionMonitorService
{
    private readonly WinBeyazEsyaTenantContext _context;

    public ConnectionMonitorManager(WinBeyazEsyaTenantContext context)
    {
        _context = context;
    }

    public async Task<bool> CheckConnectionAsync()
    {
        try
        {
            return await _context.Database.CanConnectAsync();
        }
        catch (Exception)
        {
            return false;
        }
    }
}
