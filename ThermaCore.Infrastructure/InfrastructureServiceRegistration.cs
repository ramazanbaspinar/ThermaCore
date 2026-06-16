using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ThermaCore.Application.Interfaces.Configuration;
using ThermaCore.Application.Interfaces.Mailing;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Interfaces.Security;
using ThermaCore.Infrastructure.Configuration;
using ThermaCore.Infrastructure.Mailing;
using ThermaCore.Infrastructure.Persistence;
using ThermaCore.Infrastructure.Persistence.Repositories;
using ThermaCore.Infrastructure.Security;

namespace ThermaCore.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
    {
        // DbContext
        services.AddDbContext<ThermaCoreContext>(options =>
            options.UseSqlServer(connectionString));

        // Repositories & UoW
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Infrastructure Services
        services.AddScoped<ICryptoService, CryptoService>();
        services.AddScoped<IMailService, MailService>();
        services.AddScoped<IAppConfigService, AppConfigService>();

        services.AddScoped<ThermaCore.Application.Interfaces.System.IDatabaseSeederService, ThermaCore.Infrastructure.System.DatabaseSeederManager>();
        services.AddScoped<IHardwareInfoService, HardwareInfoService>();
        services.AddScoped<ILicenseService, LicenseService>();

        return services;
    }
}
