using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ThermaCore.Application.Services.Management;
using ThermaCore.Application.Interfaces.Management;

namespace ThermaCore.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // AutoMapper ve FluentValidation kayıtları
        services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("tr-TR");

        // Manager (Service) Sınıflarının Kayıtları
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<ITerminalService, TerminalManager>();
        services.AddScoped<IBranchService, BranchManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.Security.IRoleService, ThermaCore.Application.Services.Security.RoleManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.Security.IUserPermissionService, ThermaCore.Application.Services.Security.UserPermissionManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.System.IExchangeRateService, ThermaCore.Application.Services.Management.ExchangeRateManager>();

        services.AddScoped<ThermaCore.Application.Interfaces.System.ISessionService, ThermaCore.Application.Services.System.SessionManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.System.ICodeGenerationService, ThermaCore.Application.Services.System.CodeGenerationManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.System.ILayoutService, ThermaCore.Application.Services.System.LayoutManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.System.ITenantDatabaseCrudService, ThermaCore.Application.Services.System.TenantDatabaseCrudManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.System.ITenantDatabaseSetupService, ThermaCore.Application.Services.System.TenantDatabaseSetupManager>();
        services.AddSingleton<ThermaCore.Application.Interfaces.System.ICurrentTenantService, ThermaCore.Application.Services.System.CurrentTenantService>();

        return services;
    }
}
