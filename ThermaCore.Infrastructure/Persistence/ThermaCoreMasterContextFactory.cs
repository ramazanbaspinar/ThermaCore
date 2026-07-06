using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace ThermaCore.Infrastructure.Persistence
{
    public class ThermaCoreMasterContextFactory : IDesignTimeDbContextFactory<ThermaCoreMasterContext>
    {
        public ThermaCoreMasterContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ThermaCoreMasterContext>();
            
            // Varsayılan bir connection string
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ThermaCoreMasterDb;Integrated Security=True";

            // Eğer CLI üzerinden argüman olarak ConnectionString verilmişse onu kullan
            if (args != null && args.Length > 0)
            {
                connectionString = args[0];
            }

            optionsBuilder.UseSqlServer(connectionString);

            return new ThermaCoreMasterContext(optionsBuilder.Options);
        }
    }
}
