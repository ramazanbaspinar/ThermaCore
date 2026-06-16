using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ThermaCore.Application.Services.Yonetim;

namespace ThermaCore.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // AutoMapper ve FluentValidation kayıtları
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Manager (Service) Sınıflarının Kayıtları
        services.AddScoped<IKullaniciService, KullaniciManager>();
        services.AddScoped<IKullaniciRoluService, KullaniciRoluManager>();
        services.AddScoped<ITerminalService, TerminalManager>();

        services.AddScoped<ThermaCore.Application.Interfaces.System.ISessionService, ThermaCore.Application.Services.System.SessionManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.System.ICodeGenerationService, ThermaCore.Application.Services.System.CodeGenerationManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.System.ILayoutService, ThermaCore.Application.Services.System.LayoutManager>();

        return services;
    }
}
