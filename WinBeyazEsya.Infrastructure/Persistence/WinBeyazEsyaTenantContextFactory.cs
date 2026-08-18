using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WinBeyazEsya.Infrastructure.Persistence
{
    public class WinBeyazEsyaTenantContextFactory : IDesignTimeDbContextFactory<WinBeyazEsyaTenantContext>
    {
        public WinBeyazEsyaTenantContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WinBeyazEsyaTenantContext>();

            // Varsayılan bir connection string
            //string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WinBeyazEsyaTenantDb;Integrated Security=True";
            string connectionString = "Server=192.168.2.10;Database=WinBeyazEsyaTenantDb;User Id=sa;Password=Retel3834.;Encrypt=True;TrustServerCertificate=True;";

            // Eğer CLI üzerinden argüman olarak ConnectionString verilmişse onu kullan
            if (args != null && args.Length > 0)
            {
                connectionString = args[0];
            }

            optionsBuilder.UseSqlServer(connectionString);

            // ICurrentTenantService'in boş olması tasarım anı (design-time) için sorun teşkil etmez.
            return new WinBeyazEsyaTenantContext(optionsBuilder.Options, null);
        }
    }
}

