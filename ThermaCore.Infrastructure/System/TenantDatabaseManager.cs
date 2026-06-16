using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThermaCore.Application.Interfaces.System;
using ThermaCore.Infrastructure.Persistence;

namespace ThermaCore.Infrastructure.System;

public class TenantDatabaseManager : ITenantDatabaseService
{
    public async Task CreateDatabaseAsync(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ThermaCoreTenantContext>();
        optionsBuilder.UseSqlServer(connectionString);

        using (var context = new ThermaCoreTenantContext(optionsBuilder.Options))
        {
            await context.Database.EnsureCreatedAsync();
        }
    }
}
