using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace ThermaCore.Infrastructure.Persistence
{
    public class ThermaCoreTenantContextFactory : IDesignTimeDbContextFactory<ThermaCoreTenantContext>
    {
        public ThermaCoreTenantContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ThermaCoreTenantContext>();
            
            // Varsayılan bir connection string
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ThermaCoreTenantDb;Integrated Security=True";

            // Eğer CLI üzerinden argüman olarak ConnectionString verilmişse onu kullan
            if (args != null && args.Length > 0)
            {
                connectionString = args[0];
            }

            optionsBuilder.UseSqlServer(connectionString);

            // ICurrentTenantService'in boş olması tasarım anı (design-time) için sorun teşkil etmez.
            return new ThermaCoreTenantContext(optionsBuilder.Options, null);
        }
    }
}
