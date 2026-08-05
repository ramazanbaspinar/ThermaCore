using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WinBeyazEsya.Application.Interfaces.System;
using WinBeyazEsya.Infrastructure.Persistence;

namespace WinBeyazEsya.Infrastructure.System;

public class TenantDatabaseManager : ITenantDatabaseService
{
    public async Task CreateDatabaseAsync(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<WinBeyazEsyaTenantContext>();
        optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("WinBeyazEsya.Infrastructure"));

        using (var context = new WinBeyazEsyaTenantContext(optionsBuilder.Options))
        {
            await context.Database.MigrateAsync();

            if (!await context.TaxRates.AnyAsync())
            {
                var defaultRates = new global::System.Collections.Generic.List<WinBeyazEsya.Domain.Entities.Management.TaxRate>
                {
                    new WinBeyazEsya.Domain.Entities.Management.TaxRate { Id = WinBeyazEsya.Domain.Helpers.IdGenerator.GenerateId(), TaxType = WinBeyazEsya.Domain.Enums.TaxType.Kdv, Code = "KDV01", Rate = 1, Description = "KDV %1", IsActive = true, CreatedUserId = 1, CreatedDate = global::System.DateTime.Now },
                    new WinBeyazEsya.Domain.Entities.Management.TaxRate { Id = WinBeyazEsya.Domain.Helpers.IdGenerator.GenerateId(), TaxType = WinBeyazEsya.Domain.Enums.TaxType.Kdv, Code = "KDV10", Rate = 10, Description = "KDV %10", IsActive = true, CreatedUserId = 1, CreatedDate = global::System.DateTime.Now },
                    new WinBeyazEsya.Domain.Entities.Management.TaxRate { Id = WinBeyazEsya.Domain.Helpers.IdGenerator.GenerateId(), TaxType = WinBeyazEsya.Domain.Enums.TaxType.Kdv, Code = "KDV20", Rate = 20, Description = "KDV %20", IsActive = true, CreatedUserId = 1, CreatedDate = global::System.DateTime.Now },
                    new WinBeyazEsya.Domain.Entities.Management.TaxRate { Id = WinBeyazEsya.Domain.Helpers.IdGenerator.GenerateId(), TaxType = WinBeyazEsya.Domain.Enums.TaxType.Otv, Code = "OTV10", Rate = 10, Description = "ÖTV %10", IsActive = true, CreatedUserId = 1, CreatedDate = global::System.DateTime.Now }
                };
                context.TaxRates.AddRange(defaultRates);
                await context.SaveChangesAsync();
            }
        }
    }

    public async Task CreateMasterDatabaseAsync(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<WinBeyazEsyaMasterContext>();
        optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("WinBeyazEsya.Infrastructure"));

        using (var context = new WinBeyazEsyaMasterContext(optionsBuilder.Options))
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

