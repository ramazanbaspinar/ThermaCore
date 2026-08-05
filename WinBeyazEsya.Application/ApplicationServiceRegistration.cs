using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Application.Services.Management;
using WinBeyazEsya.Application.Interfaces.Management;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Services.Definitions;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Validators.Definitions;

namespace WinBeyazEsya.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // AutoMapper ve FluentValidation kayıtları
        services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssemblyContaining<WinBeyazEsya.Application.Validations.Definitions.UnitValidator>();
        ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("tr-TR");

        // Manager (Service) Sınıflarının Kayıtları
        services.AddScoped<IHandleService, HandleManager>();
        services.AddScoped<IUnitConversionService, UnitConversionManager>();
        services.AddScoped<IValidator<HandleDto>, HandleValidator>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Definitions.UnitConversionDto>, WinBeyazEsya.Application.Validations.Definitions.UnitConversionValidator>();
        services.AddScoped<IFittingService, FittingManager>();
        services.AddScoped<IValidator<FittingDto>, FittingValidator>();
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<ITerminalService, TerminalManager>();
        services.AddScoped<IBranchService, BranchManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Security.IRoleService, WinBeyazEsya.Application.Services.Security.RoleManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Security.IUserPermissionService, WinBeyazEsya.Application.Services.Security.UserPermissionManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.System.IExchangeRateService, WinBeyazEsya.Application.Services.Management.ExchangeRateManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Management.ITaxRateService, WinBeyazEsya.Application.Services.Management.TaxRateManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.IThermostatService, WinBeyazEsya.Application.Services.Production.ThermostatManager>();
        services.AddScoped<ISystemParameterService, SystemParameterManager>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Management.CodeTemplateDto>, WinBeyazEsya.Application.Validations.Management.CodeTemplateValidator>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Management.CodeLogDto>, WinBeyazEsya.Application.Validations.Management.CodeLogValidator>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Management.MaliyetParametreDto>, WinBeyazEsya.Application.Validations.Management.MaliyetParametreValidator>();

        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.QualityStandardDto>, WinBeyazEsya.Application.Validations.Production.QualityStandardValidator>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.SurfaceTypeDto>, WinBeyazEsya.Application.Validations.Production.SurfaceTypeValidator>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.SheetMetalDto>, WinBeyazEsya.Application.Validations.Production.SheetMetalValidator>();

        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.BoyaDto>, WinBeyazEsya.Application.Validations.Production.BoyaValidator>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.EmayeDto>, WinBeyazEsya.Application.Validations.Production.EmayeValidator>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Common.ItemBarcodeDto>, WinBeyazEsya.Application.Validations.Common.ItemBarcodeValidator>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Common.SpecialCodeDto>, WinBeyazEsya.Application.Validations.Common.SpecialCodeValidator>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.ThermostatDto>, WinBeyazEsya.Application.Validations.Production.ThermostatValidator>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.GlassTypeDto>, WinBeyazEsya.Application.Validators.Production.GlassTypeValidator>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.ColorFeatureDto>, WinBeyazEsya.Application.Validators.Production.ColorFeatureValidator>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.OvenGlassDto>, WinBeyazEsya.Application.Validators.Production.OvenGlassValidator>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.CableDto>, WinBeyazEsya.Application.Validators.Production.CableValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.IQualityStandardService, WinBeyazEsya.Application.Services.Production.QualityStandardManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.ISurfaceTypeService, WinBeyazEsya.Application.Services.Production.SurfaceTypeManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.ISheetMetalService, WinBeyazEsya.Application.Services.Production.SheetMetalManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.IBoyaService, WinBeyazEsya.Application.Services.Production.BoyaManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.IEmayeService, WinBeyazEsya.Application.Services.Production.EmayeManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.IScrewService, WinBeyazEsya.Application.Services.Production.ScrewManager>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.RotarySwitchDto>, WinBeyazEsya.Application.Validations.Production.RotarySwitchValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.IRotarySwitchService, WinBeyazEsya.Application.Services.Production.RotarySwitchManager>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.HeatingElementDto>, WinBeyazEsya.Application.Validations.Production.HeatingElementValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.IHeatingElementService, WinBeyazEsya.Application.Services.Production.HeatingElementManager>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.OvenTimerDto>, WinBeyazEsya.Application.Validations.Production.OvenTimerValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.IOvenTimerService, WinBeyazEsya.Application.Services.Production.OvenTimerManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.IKnobService, WinBeyazEsya.Application.Services.Production.KnobManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.IGlassTypeService, WinBeyazEsya.Application.Services.Production.GlassTypeManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.IColorFeatureService, WinBeyazEsya.Application.Services.Production.ColorFeatureManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.IOvenGlassService, WinBeyazEsya.Application.Services.Production.OvenGlassManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.ICableService, WinBeyazEsya.Application.Services.Production.CableManager>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.HotplateDto>, WinBeyazEsya.Application.Validators.Production.HotplateValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.IHotplateService, WinBeyazEsya.Application.Services.Production.HotplateManager>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.OvenLampDto>, WinBeyazEsya.Application.ValidationRules.Production.OvenLampValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.IOvenLampService, WinBeyazEsya.Application.Services.Production.OvenLampManager>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.OvenMotorDto>, WinBeyazEsya.Application.Validators.Production.OvenMotorValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.IOvenMotorService, WinBeyazEsya.Application.Services.Production.OvenMotorManager>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.OvenFanDto>, WinBeyazEsya.Application.Validators.Production.OvenFanValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.IOvenFanService, WinBeyazEsya.Application.Services.Production.OvenFanManager>();
        
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.GasValveDto>, WinBeyazEsya.Application.Validators.Production.GasValveValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.IGasValveService, WinBeyazEsya.Application.Services.Production.GasValveManager>();
        
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.BurnerDto>, WinBeyazEsya.Application.Validators.Production.BurnerValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.IBurnerService, WinBeyazEsya.Application.Services.Production.BurnerManager>();

        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.InjectorDto>, WinBeyazEsya.Application.Validators.Production.InjectorValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.IInjectorService, WinBeyazEsya.Application.Services.Production.InjectorManager>();
        
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.ValveDto>, WinBeyazEsya.Application.Validators.Production.ValveValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.IValveService, WinBeyazEsya.Application.Services.Production.ValveManager>();

        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.ThermocoupleDto>, WinBeyazEsya.Application.Validators.Production.ThermocoupleValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.IThermocoupleService, WinBeyazEsya.Application.Services.Production.ThermocoupleManager>();

        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.SparkPlugDto>, WinBeyazEsya.Application.Validators.Production.SparkPlugValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.ISparkPlugService, WinBeyazEsya.Application.Services.Production.SparkPlugManager>();

        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.IgnitionTransformerDto>, WinBeyazEsya.Application.Validations.Production.IgnitionTransformerValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.IIgnitionTransformerService, WinBeyazEsya.Application.Services.Production.IgnitionTransformerManager>();
        
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.GasPipeDto>, WinBeyazEsya.Application.Validations.Production.GasPipeValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.IGasPipeService, WinBeyazEsya.Application.Services.Production.GasPipeManager>();
        
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Production.MaterialCostDto>, WinBeyazEsya.Application.Validations.Production.MaterialCostValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.IMaterialCostService, WinBeyazEsya.Application.Services.Production.MaterialCostManager>();

        services.AddScoped<WinBeyazEsya.Application.Interfaces.Common.IItemBarcodeService, WinBeyazEsya.Application.Services.Common.ItemBarcodeManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Common.IBarcodePrintService, WinBeyazEsya.Application.Services.Common.BarcodePrintManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Common.IDocumentService, WinBeyazEsya.Application.Services.Common.DocumentManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Common.ISpecialCodeService, WinBeyazEsya.Application.Services.Common.SpecialCodeManager>();

        services.AddScoped<WinBeyazEsya.Application.Interfaces.System.ISessionService, WinBeyazEsya.Application.Services.System.SessionManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.System.ICodeGenerationService, WinBeyazEsya.Application.Services.System.CodeGenerationManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.System.ILayoutService, WinBeyazEsya.Application.Services.System.LayoutManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.System.ITenantDatabaseCrudService, WinBeyazEsya.Application.Services.System.TenantDatabaseCrudManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.System.ITenantDatabaseSetupService, WinBeyazEsya.Application.Services.System.TenantDatabaseSetupManager>();
        services.AddSingleton<WinBeyazEsya.Application.Interfaces.System.ICurrentTenantService, WinBeyazEsya.Application.Services.System.CurrentTenantService>();

        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Definitions.HingeDto>, WinBeyazEsya.Application.Validations.Definitions.HingeValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Definitions.IHingeService, WinBeyazEsya.Application.Services.Definitions.HingeManager>();
        
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Definitions.GasketDto>, WinBeyazEsya.Application.Validations.Definitions.GasketValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Definitions.IGasketService, WinBeyazEsya.Application.Services.Definitions.GasketManager>();
        
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Definitions.InsulationDto>, WinBeyazEsya.Application.Validations.Definitions.InsulationValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Definitions.IInsulationService, WinBeyazEsya.Application.Services.Definitions.InsulationManager>();
        
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Definitions.WireDto>, WinBeyazEsya.Application.Validations.Definitions.WireValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Definitions.IWireService, WinBeyazEsya.Application.Services.Definitions.WireManager>();

        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Definitions.GridDto>, WinBeyazEsya.Application.Validators.Definitions.GridValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Definitions.IGridService, WinBeyazEsya.Application.Services.Definitions.GridManager>();
        
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Definitions.TrayDto>, WinBeyazEsya.Application.Validators.Definitions.TrayValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Definitions.ITrayService, WinBeyazEsya.Application.Services.Definitions.TrayManager>();
        
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Definitions.HandleDto>, WinBeyazEsya.Application.Validators.Definitions.HandleValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Definitions.IHandleService, WinBeyazEsya.Application.Services.Definitions.HandleManager>();
        
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
        
        services.AddScoped<IValidator<ProductLabelDto>, WinBeyazEsya.Application.Validations.Definitions.ProductLabelValidator>();
        services.AddScoped<IProductLabelService, ProductLabelManager>();
        
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Definitions.GeneralExpenseDto>, WinBeyazEsya.Application.Validations.Definitions.GeneralExpenseValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Definitions.IGeneralExpenseService, WinBeyazEsya.Application.Services.Definitions.GeneralExpenseManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Management.ISystemParameterService, WinBeyazEsya.Application.Services.Management.SystemParameterManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Updater.IAutoUpdateService, WinBeyazEsya.Application.Services.Updater.AutoUpdateManager>();        
        return services;
    }
}

