using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Application.Interfaces.Configuration;
using WinBeyazEsya.Application.Interfaces.Mailing;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Interfaces.Security;
using WinBeyazEsya.Infrastructure.Configuration;
using WinBeyazEsya.Infrastructure.Mailing;
using WinBeyazEsya.Infrastructure.Persistence;
using WinBeyazEsya.Infrastructure.Persistence.Repositories;
using WinBeyazEsya.Infrastructure.Security;

namespace WinBeyazEsya.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
    {
        // DbContext
        services.AddDbContext<WinBeyazEsyaMasterContext>(options =>
            options.UseSqlServer(connectionString, b => 
            {
                b.MigrationsAssembly("WinBeyazEsya.Infrastructure");
                b.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(2), errorNumbersToAdd: null);
                b.CommandTimeout(5);
            }));

        services.AddSingleton<WinBeyazEsya.Infrastructure.System.TenantConnectionStringInterceptor>();

        services.AddDbContext<WinBeyazEsyaTenantContext>((sp, options) => {
            options.UseSqlServer(connectionString, b => 
            {
                b.MigrationsAssembly("WinBeyazEsya.Infrastructure");
                b.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(2), errorNumbersToAdd: null);
                b.CommandTimeout(5);
            });
            options.AddInterceptors(sp.GetRequiredService<WinBeyazEsya.Infrastructure.System.TenantConnectionStringInterceptor>());
        });

        // Repositories & UoW
        services.AddScoped(typeof(IMasterRepository<>), typeof(MasterRepository<>));
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IMasterUnitOfWork, MasterUnitOfWork>();

        // Infrastructure Services
        services.AddScoped<ICryptoService, CryptoService>();
        services.AddScoped<IMailService, MailService>();
        services.AddScoped<IAppConfigService, AppConfigService>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.System.IConnectionMonitorService, WinBeyazEsya.Infrastructure.System.ConnectionMonitorManager>();

        services.AddScoped<WinBeyazEsya.Application.Interfaces.System.IDatabaseSeederService, WinBeyazEsya.Infrastructure.System.DatabaseSeederManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.System.ITenantDatabaseService, WinBeyazEsya.Infrastructure.System.TenantDatabaseManager>();
        services.AddScoped<IHardwareInfoService, HardwareInfoService>();
        services.AddScoped<ILicenseService, LicenseService>();
        services.AddScoped<ILicenseValidator, LicenseValidator>();
        services.AddSingleton<WinBeyazEsya.Application.Interfaces.System.ILayoutService, WinBeyazEsya.Infrastructure.Services.System.LayoutService>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Repositories.ICodeLogRepository, WinBeyazEsya.Infrastructure.Persistence.Repositories.CodeLogRepository>();
        
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Repositories.Definitions.IUnitRepository, WinBeyazEsya.Infrastructure.Persistence.Repositories.Definitions.UnitRepository>();
        return services;
    }
}

