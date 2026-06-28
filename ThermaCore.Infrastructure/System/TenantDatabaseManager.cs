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

            if (!await context.TaxRates.AnyAsync())
            {
                var defaultRates = new global::System.Collections.Generic.List<ThermaCore.Domain.Entities.Management.TaxRate>
                {
                    new ThermaCore.Domain.Entities.Management.TaxRate { Id = ThermaCore.Domain.Helpers.IdGenerator.GenerateId(), TaxType = ThermaCore.Domain.Enums.TaxType.Kdv, Code = "KDV01", Rate = 1, Description = "KDV %1", IsActive = true, CreatedUserId = 1, CreatedDate = global::System.DateTime.Now },
                    new ThermaCore.Domain.Entities.Management.TaxRate { Id = ThermaCore.Domain.Helpers.IdGenerator.GenerateId(), TaxType = ThermaCore.Domain.Enums.TaxType.Kdv, Code = "KDV10", Rate = 10, Description = "KDV %10", IsActive = true, CreatedUserId = 1, CreatedDate = global::System.DateTime.Now },
                    new ThermaCore.Domain.Entities.Management.TaxRate { Id = ThermaCore.Domain.Helpers.IdGenerator.GenerateId(), TaxType = ThermaCore.Domain.Enums.TaxType.Kdv, Code = "KDV20", Rate = 20, Description = "KDV %20", IsActive = true, CreatedUserId = 1, CreatedDate = global::System.DateTime.Now },
                    new ThermaCore.Domain.Entities.Management.TaxRate { Id = ThermaCore.Domain.Helpers.IdGenerator.GenerateId(), TaxType = ThermaCore.Domain.Enums.TaxType.Otv, Code = "OTV10", Rate = 10, Description = "ÖTV %10", IsActive = true, CreatedUserId = 1, CreatedDate = global::System.DateTime.Now }
                };
                context.TaxRates.AddRange(defaultRates);
                await context.SaveChangesAsync();
            }
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
