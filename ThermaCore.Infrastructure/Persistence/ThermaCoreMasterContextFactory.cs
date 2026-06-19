using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ThermaCore.Infrastructure.Persistence;

public class ThermaCoreMasterContextFactory : IDesignTimeDbContextFactory<ThermaCoreMasterContext>
{
    public ThermaCoreMasterContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ThermaCoreMasterContext>();
        
        // Bu bağlantı dizesi yalnızca EF Core Migration'ları (add-migration) komutlarını çalıştırabilmek için tasarım zamanında kullanılır.
        // Gerçek çalışma zamanındaki bağlantı dizesi ile ilgisi yoktur.
        optionsBuilder.UseSqlServer("Server=localhost;Database=ThermaCore_Master_Design;Trusted_Connection=True;TrustServerCertificate=True");

        return new ThermaCoreMasterContext(optionsBuilder.Options);
    }
}
