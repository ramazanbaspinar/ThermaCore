using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Infrastructure.Persistence;
using WinBeyazEsya.Infrastructure.Security;

class Program
{
    static void Main()
    {
        var services = new ServiceCollection();
        
        var configService = new WinBeyazEsya.Infrastructure.Configuration.AppConfigService();
        string connStr = configService.GetConnectionString();
        if (string.IsNullOrEmpty(connStr)) {
            Console.WriteLine("Connection string not found.");
            return;
        }

        services.AddDbContext<WinBeyazEsyaMasterContext>(options =>
            options.UseSqlServer(connStr));

        var sp = services.BuildServiceProvider();
        using var scope = sp.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<WinBeyazEsyaMasterContext>();
        var cryptoService = new CryptoService();

        var tenants = context.TenantDatabases.ToList();
        Console.WriteLine($"Found {tenants.Count} tenants.");
        foreach(var t in tenants)
        {
            Console.WriteLine($"Tenant: {t.Code} - {t.DatabaseName}");
            Console.WriteLine($"Server: {t.Server}");
            Console.WriteLine($"AuthType: {t.AuthType}");
            Console.WriteLine($"Username: {t.Username}");
            Console.WriteLine($"Raw Password in DB: {t.Password}");
            
            string decrypted = "";
            try {
                decrypted = cryptoService.Decrypt(t.Password);
            } catch (Exception ex) {
                decrypted = "EXCEPTION: " + ex.Message;
            }
            Console.WriteLine($"Decrypted Password: {decrypted}");
            Console.WriteLine("-------------------------------------------------");
        }
    }
}
