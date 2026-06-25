using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ThermaCore.Infrastructure.Persistence;

public class ThermaCoreTenantContextFactory : IDesignTimeDbContextFactory<ThermaCoreTenantContext>
{
    public ThermaCoreTenantContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ThermaCoreTenantContext>();
        
        string connectionString = "Server=localhost;Database=ThermaCore_Tenant_Design;Trusted_Connection=True;TrustServerCertificate=True";

        if (args != null && args.Length > 0)
        {
            connectionString = args[0];
        }

        optionsBuilder.UseSqlServer(connectionString);

        return new ThermaCoreTenantContext(optionsBuilder.Options);
    }
}
