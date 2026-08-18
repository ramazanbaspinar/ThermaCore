using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WinBeyazEsya.Infrastructure.Persistence
{
    public class WinBeyazEsyaMasterContextFactory : IDesignTimeDbContextFactory<WinBeyazEsyaMasterContext>
    {
        public WinBeyazEsyaMasterContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WinBeyazEsyaMasterContext>();

            // Varsayılan bir connection string
            //string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WinBeyazEsyaMasterDb;Integrated Security=True";
            string connectionString = "Server=192.168.2.10;Database=WinBeyazEsyaMasterDb;User Id=sa;Password=Retel3834.;Encrypt=True;TrustServerCertificate=True;";

            // Eğer CLI üzerinden argüman olarak ConnectionString verilmişse onu kullan
            if (args != null && args.Length > 0)
            {
                connectionString = args[0];
            }

            optionsBuilder.UseSqlServer(connectionString);

            return new WinBeyazEsyaMasterContext(optionsBuilder.Options);
        }
    }
}

