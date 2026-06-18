using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ThermaCore.Application.Services.Management;

namespace ThermaCore.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // AutoMapper ve FluentValidation kayıtları
        services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Manager (Service) Sınıflarının Kayıtları
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IUserRoleService, UserRoleManager>();
        services.AddScoped<ITerminalService, TerminalManager>();
        services.AddScoped<IBranchService, BranchManager>();

        services.AddScoped<ThermaCore.Application.Interfaces.System.ISessionService, ThermaCore.Application.Services.System.SessionManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.System.ICodeGenerationService, ThermaCore.Application.Services.System.CodeGenerationManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.System.ILayoutService, ThermaCore.Application.Services.System.LayoutManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.System.ITenantDatabaseCrudService, ThermaCore.Application.Services.System.TenantDatabaseCrudManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.System.ITenantDatabaseSetupService, ThermaCore.Application.Services.System.TenantDatabaseSetupManager>();
        services.AddSingleton<ThermaCore.Application.Interfaces.System.ICurrentTenantService, ThermaCore.Application.Services.System.CurrentTenantService>();

        return services;
    }
}
