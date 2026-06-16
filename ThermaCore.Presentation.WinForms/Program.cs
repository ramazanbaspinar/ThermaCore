using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ThermaCore.Application;
using ThermaCore.Application.Interfaces.Configuration;
using ThermaCore.Application.Interfaces.Security;
using ThermaCore.Application.Interfaces.System;
using ThermaCore.Domain.Enums;
using ThermaCore.Infrastructure;
using ThermaCore.Infrastructure.Configuration;
using ThermaCore.Presentation.WinForms.Forms.GenelForms;

namespace ThermaCore.Presentation.WinForms;

internal static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; } = default!;

    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        IAppConfigService configService = new AppConfigService();
        string connectionString = configService.GetConnectionString();

        bool isConnected = false;
        if (!string.IsNullOrEmpty(connectionString))
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    isConnected = true;
                }
            }
            catch
            {
                isConnected = false;
            }
        }

        if (!isConnected)
        {
            // Kurulum sihirbazı ve veritabanı servisleri için bağımlılıkları manuel çözüyoruz
            ThermaCore.Application.Interfaces.System.ITenantDatabaseService tenantDbService = new ThermaCore.Infrastructure.System.TenantDatabaseManager();
            ITenantDatabaseSetupService sistemVeritabaniService = new ThermaCore.Application.Services.System.TenantDatabaseSetupManager(null!, null!, tenantDbService);

            System.Windows.Forms.Application.Run(new BaglantiHataForm(configService, sistemVeritabaniService));
            return;
        }

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddApplicationServices();
                services.AddInfrastructureServices(connectionString);

                services.AddTransient<GirisForm>();
            })
            .Build();

        ServiceProvider = host.Services;

        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var licenseService = services.GetRequiredService<ILicenseService>();
                var status = licenseService.CheckLicense(out string message);
                
                if (status != LicenseStatus.Valid && status != LicenseStatus.Demo)
                {
                    MessageBox.Show($"Lisans hatası: {message}\nLütfen sistem yöneticinizle iletişime geçin.", "ThermaCore Lisans", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var seederService = services.GetRequiredService<IDatabaseSeederService>();
                seederService.SeedAsync(true).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Başlangıç hatası: {ex.Message}", "ThermaCore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        var mainForm = host.Services.GetRequiredService<GirisForm>();
        System.Windows.Forms.Application.Run(mainForm);
    }
}