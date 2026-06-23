using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ThermaCore.Infrastructure.Persistence;

public class ThermaCoreTenantContextFactory : IDesignTimeDbContextFactory<ThermaCoreTenantContext>
{
    public ThermaCoreTenantContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ThermaCoreTenantContext>();
        
        // Bu bağlantı dizesi yalnızca EF Core Migration'ları (add-migration) komutlarını çalıştırabilmek için tasarım zamanında kullanılır.
        optionsBuilder.UseSqlServer("Server=localhost;Database=ThermaCore_Tenant_Design;Trusted_Connection=True;TrustServerCertificate=True");

        return new ThermaCoreTenantContext(optionsBuilder.Options);
    }
}
