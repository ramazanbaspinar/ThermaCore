using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Infrastructure.Persistence;

class Program
{
    static void Main()
    {
        var services = new ServiceCollection();
        
        // Settings'den connection string oku
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

        var tenants = context.TenantDatabases.ToList();
        foreach(var t in tenants)
        {
            t.AuthType = WinBeyazEsya.Domain.Enums.AuthenticationType.Windows;
            t.Username = "";
            t.Password = "";
        }
        context.SaveChanges();
        Console.WriteLine("Tüm Şirket (Tenant) veritabanı bağlantıları başarıyla Windows Authentication olarak güncellendi.");
    }
}
