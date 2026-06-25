using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ThermaCore.Infrastructure.Persistence;

public class ThermaCoreMasterContextFactory : IDesignTimeDbContextFactory<ThermaCoreMasterContext>
{
    public ThermaCoreMasterContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ThermaCoreMasterContext>();
        
        string connectionString = "Server=localhost;Database=ThermaCore_Master_Design;Trusted_Connection=True;TrustServerCertificate=True";

        if (args != null && args.Length > 0)
        {
            connectionString = args[0];
        }

        optionsBuilder.UseSqlServer(connectionString);

        return new ThermaCoreMasterContext(optionsBuilder.Options);
    }
}
