using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using WinBeyazEsya.Application.Interfaces.System;

namespace WinBeyazEsya.Infrastructure.System;

public class TenantConnectionStringInterceptor : DbConnectionInterceptor
{
    private readonly ICurrentTenantService _currentTenantService;

    public TenantConnectionStringInterceptor(ICurrentTenantService currentTenantService)
    {
        _currentTenantService = currentTenantService;
    }

    public override InterceptionResult ConnectionOpening(DbConnection connection, ConnectionEventData eventData, InterceptionResult result)
    {
        UpdateConnectionString(connection);
        return base.ConnectionOpening(connection, eventData, result);
    }

    public override ValueTask<InterceptionResult> ConnectionOpeningAsync(DbConnection connection, ConnectionEventData eventData, InterceptionResult result, CancellationToken cancellationToken = default)
    {
        UpdateConnectionString(connection);
        return base.ConnectionOpeningAsync(connection, eventData, result, cancellationToken);
    }

    private void UpdateConnectionString(DbConnection connection)
    {
        if (_currentTenantService != null && !string.IsNullOrEmpty(_currentTenantService.ConnectionString))
        {
            if (connection.ConnectionString != _currentTenantService.ConnectionString)
            {
                connection.ConnectionString = _currentTenantService.ConnectionString;
            }
        }
    }
}

