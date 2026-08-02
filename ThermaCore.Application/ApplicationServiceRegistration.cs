using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ThermaCore.Application.Services.Management;
using ThermaCore.Application.Interfaces.Management;
using ThermaCore.Application.Interfaces.Definitions;
using ThermaCore.Application.Services.Definitions;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Application.Validators.Definitions;

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
        services.AddScoped<IHandleService, HandleManager>();
        services.AddScoped<IUnitConversionService, UnitConversionManager>();
        services.AddScoped<IValidator<HandleDto>, HandleValidator>();
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Definitions.UnitConversionDto>, ThermaCore.Application.Validations.Definitions.UnitConversionValidator>();
        services.AddScoped<IFittingService, FittingManager>();
        services.AddScoped<IValidator<FittingDto>, FittingValidator>();
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
        
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.ValveDto>, ThermaCore.Application.Validators.Production.ValveValidator>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.IValveService, ThermaCore.Application.Services.Production.ValveManager>();

        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.ThermocoupleDto>, ThermaCore.Application.Validators.Production.ThermocoupleValidator>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.IThermocoupleService, ThermaCore.Application.Services.Production.ThermocoupleManager>();

        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.SparkPlugDto>, ThermaCore.Application.Validators.Production.SparkPlugValidator>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.ISparkPlugService, ThermaCore.Application.Services.Production.SparkPlugManager>();

        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.IgnitionTransformerDto>, ThermaCore.Application.Validations.Production.IgnitionTransformerValidator>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.IIgnitionTransformerService, ThermaCore.Application.Services.Production.IgnitionTransformerManager>();
        
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.GasPipeDto>, ThermaCore.Application.Validations.Production.GasPipeValidator>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.IGasPipeService, ThermaCore.Application.Services.Production.GasPipeManager>();
        
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Production.MaterialCostDto>, ThermaCore.Application.Validations.Production.MaterialCostValidator>();
        services.AddScoped<ThermaCore.Application.Interfaces.Production.IMaterialCostService, ThermaCore.Application.Services.Production.MaterialCostManager>();

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

        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Definitions.HingeDto>, ThermaCore.Application.Validations.Definitions.HingeValidator>();
        services.AddScoped<ThermaCore.Application.Interfaces.Definitions.IHingeService, ThermaCore.Application.Services.Definitions.HingeManager>();
        
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Definitions.GasketDto>, ThermaCore.Application.Validations.Definitions.GasketValidator>();
        services.AddScoped<ThermaCore.Application.Interfaces.Definitions.IGasketService, ThermaCore.Application.Services.Definitions.GasketManager>();
        
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Definitions.InsulationDto>, ThermaCore.Application.Validations.Definitions.InsulationValidator>();
        services.AddScoped<ThermaCore.Application.Interfaces.Definitions.IInsulationService, ThermaCore.Application.Services.Definitions.InsulationManager>();
        
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Definitions.WireDto>, ThermaCore.Application.Validations.Definitions.WireValidator>();
        services.AddScoped<ThermaCore.Application.Interfaces.Definitions.IWireService, ThermaCore.Application.Services.Definitions.WireManager>();

        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Definitions.GridDto>, ThermaCore.Application.Validators.Definitions.GridValidator>();
        services.AddScoped<ThermaCore.Application.Interfaces.Definitions.IGridService, ThermaCore.Application.Services.Definitions.GridManager>();
        
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Definitions.TrayDto>, ThermaCore.Application.Validators.Definitions.TrayValidator>();
        services.AddScoped<ThermaCore.Application.Interfaces.Definitions.ITrayService, ThermaCore.Application.Services.Definitions.TrayManager>();
        
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Definitions.HandleDto>, ThermaCore.Application.Validators.Definitions.HandleValidator>();
        services.AddScoped<ThermaCore.Application.Interfaces.Definitions.IHandleService, ThermaCore.Application.Services.Definitions.HandleManager>();
        
        services.AddScoped<IValidator<PlasticPartDto>, PlasticPartValidator>();
        services.AddScoped<IPlasticPartService, PlasticPartManager>();
        
        services.AddScoped<IValidator<LockDto>, LockValidator>();
        services.AddScoped<ILockService, LockManager>();
        
        services.AddScoped<IValidator<FastenerDto>, FastenerValidator>();
        services.AddScoped<IFastenerService, FastenerManager>();
        
        services.AddScoped<IValidator<PackagingMaterialDto>, PackagingMaterialValidator>();
        services.AddScoped<IValidator<ManualDto>, ManualValidator>();
        services.AddScoped<IPackagingMaterialService, PackagingMaterialManager>();
        services.AddScoped<IManualService, ManualManager>();
        
        services.AddScoped<IValidator<ProductLabelDto>, ThermaCore.Application.Validations.Definitions.ProductLabelValidator>();
        services.AddScoped<IProductLabelService, ProductLabelManager>();
        
        services.AddScoped<IValidator<ThermaCore.Application.DTOs.Definitions.GeneralExpenseDto>, ThermaCore.Application.Validations.Definitions.GeneralExpenseValidator>();
        services.AddScoped<ThermaCore.Application.Interfaces.Definitions.IGeneralExpenseService, ThermaCore.Application.Services.Definitions.GeneralExpenseManager>();
        
        return services;
    }
}
