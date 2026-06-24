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
        optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("ThermaCore.Infrastructure"));

        using (var context = new ThermaCoreTenantContext(optionsBuilder.Options))
        {
            await context.Database.MigrateAsync();
        }
    }

    public async Task CreateMasterDatabaseAsync(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ThermaCoreMasterContext>();
        optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("ThermaCore.Infrastructure"));

        using (var context = new ThermaCoreMasterContext(optionsBuilder.Options))
        {
            await context.Database.MigrateAsync();
        }
    }

    public async Task<bool> CheckDatabaseExistsAsync(string masterConnectionString, string databaseName)
    {
        using (var connection = new Microsoft.Data.SqlClient.SqlConnection(masterConnectionString))
        {
            await connection.OpenAsync();
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = $"SELECT db_id('{databaseName.Replace("'", "''")}')";
                var result = await cmd.ExecuteScalarAsync();
                return result != global::System.DBNull.Value && result != null;
            }
        }
    }
}
