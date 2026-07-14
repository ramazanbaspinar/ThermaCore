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
        services.AddValidatorsFromAssemblyContaining<ThermaCore.Application.Validations.Definitions.UnitValidator>();
        ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("tr-TR");

        // Manager (Service) Sınıflarının Kayıtları
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<ITerminalService, TerminalManager>();
        services.AddScoped<IBranchService, BranchManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.Security.IRoleService, ThermaCore.Application.Services.Security.RoleManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.Security.IUserPermissionService, ThermaCore.Application.Services.Security.UserPermissionManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.System.IExchangeRateService, ThermaCore.Application.Services.Management.ExchangeRateManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.Management.ITaxRateService, ThermaCore.Application.Services.Management.TaxRateManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.IThermostatService, ThermaCore.Application.Services.Production.ThermostatManager>();
        services.AddScoped<ISystemParameterService, SystemParameterManager>();
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Management.CodeTemplateDto>, ThermaCore.Application.Validations.Management.CodeTemplateValidator>();
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Management.CodeLogDto>, ThermaCore.Application.Validations.Management.CodeLogValidator>();

        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.QualityStandardDto>, ThermaCore.Application.Validations.Production.QualityStandardValidator>();
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.SurfaceTypeDto>, ThermaCore.Application.Validations.Production.SurfaceTypeValidator>();
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.SheetMetalDto>, ThermaCore.Application.Validations.Production.SheetMetalValidator>();

        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.BoyaDto>, ThermaCore.Application.Validations.Production.BoyaValidator>();
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.EmayeDto>, ThermaCore.Application.Validations.Production.EmayeValidator>();
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Common.ItemBarcodeDto>, ThermaCore.Application.Validations.Common.ItemBarcodeValidator>();
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Common.SpecialCodeDto>, ThermaCore.Application.Validations.Common.SpecialCodeValidator>();
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.ThermostatDto>, ThermaCore.Application.Validations.Production.ThermostatValidator>();
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.GlassTypeDto>, ThermaCore.Application.Validators.Production.GlassTypeValidator>();
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.ColorFeatureDto>, ThermaCore.Application.Validators.Production.ColorFeatureValidator>();
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.OvenGlassDto>, ThermaCore.Application.Validators.Production.OvenGlassValidator>();
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.CableDto>, ThermaCore.Application.Validators.Production.CableValidator>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.IQualityStandardService, ThermaCore.Application.Services.Production.QualityStandardManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.ISurfaceTypeService, ThermaCore.Application.Services.Production.SurfaceTypeManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.ISheetMetalService, ThermaCore.Application.Services.Production.SheetMetalManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.IBoyaService, ThermaCore.Application.Services.Production.BoyaManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.IEmayeService, ThermaCore.Application.Services.Production.EmayeManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.IScrewService, ThermaCore.Application.Services.Production.ScrewManager>();
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.RotarySwitchDto>, ThermaCore.Application.Validations.Production.RotarySwitchValidator>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.IRotarySwitchService, ThermaCore.Application.Services.Production.RotarySwitchManager>();
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.HeatingElementDto>, ThermaCore.Application.Validations.Production.HeatingElementValidator>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.IHeatingElementService, ThermaCore.Application.Services.Production.HeatingElementManager>();
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.OvenTimerDto>, ThermaCore.Application.Validations.Production.OvenTimerValidator>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.IOvenTimerService, ThermaCore.Application.Services.Production.OvenTimerManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.IKnobService, ThermaCore.Application.Services.Production.KnobManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.IGlassTypeService, ThermaCore.Application.Services.Production.GlassTypeManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.IColorFeatureService, ThermaCore.Application.Services.Production.ColorFeatureManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.IOvenGlassService, ThermaCore.Application.Services.Production.OvenGlassManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.ICableService, ThermaCore.Application.Services.Production.CableManager>();
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.HotplateDto>, ThermaCore.Application.Validators.Production.HotplateValidator>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.IHotplateService, ThermaCore.Application.Services.Production.HotplateManager>();
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.OvenLampDto>, ThermaCore.Application.ValidationRules.Production.OvenLampValidator>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.IOvenLampService, ThermaCore.Application.Services.Production.OvenLampManager>();
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.OvenMotorDto>, ThermaCore.Application.Validators.Production.OvenMotorValidator>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.IOvenMotorService, ThermaCore.Application.Services.Production.OvenMotorManager>();
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.OvenFanDto>, ThermaCore.Application.Validators.Production.OvenFanValidator>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.IOvenFanService, ThermaCore.Application.Services.Production.OvenFanManager>();
        
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.GasValveDto>, ThermaCore.Application.Validators.Production.GasValveValidator>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.IGasValveService, ThermaCore.Application.Services.Production.GasValveManager>();
        
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.BurnerDto>, ThermaCore.Application.Validators.Production.BurnerValidator>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.IBurnerService, ThermaCore.Application.Services.Production.BurnerManager>();

        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.InjectorDto>, ThermaCore.Application.Validators.Production.InjectorValidator>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.IInjectorService, ThermaCore.Application.Services.Production.InjectorManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.Common.IItemBarcodeService, ThermaCore.Application.Services.Common.ItemBarcodeManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.Common.IBarcodePrintService, ThermaCore.Application.Services.Common.BarcodePrintManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.Common.IDocumentService, ThermaCore.Application.Services.Common.DocumentManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.Common.ISpecialCodeService, ThermaCore.Application.Services.Common.SpecialCodeManager>();

        services.AddScoped<ThermaCore.Application.Interfaces.System.ISessionService, ThermaCore.Application.Services.System.SessionManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.System.ICodeGenerationService, ThermaCore.Application.Services.System.CodeGenerationManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.System.ILayoutService, ThermaCore.Application.Services.System.LayoutManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.System.ITenantDatabaseCrudService, ThermaCore.Application.Services.System.TenantDatabaseCrudManager>();
        services.AddScoped<ThermaCore.Application.Interfaces.System.ITenantDatabaseSetupService, ThermaCore.Application.Services.System.TenantDatabaseSetupManager>();
        services.AddSingleton<ThermaCore.Application.Interfaces.System.ICurrentTenantService, ThermaCore.Application.Services.System.CurrentTenantService>();

        return services;
    }
}
