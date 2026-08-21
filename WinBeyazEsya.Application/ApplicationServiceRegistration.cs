using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Management;
using WinBeyazEsya.Application.Services.Definitions;
using WinBeyazEsya.Application.Services.Management;

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
        services.AddScoped<IUnitConversionService, UnitConversionManager>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Definitions.UnitConversionDto>, WinBeyazEsya.Application.Validations.Definitions.UnitConversionValidator>();
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IUserFavoriteService, UserFavoriteManager>();
        services.AddScoped<IWarehouseService, WarehouseManager>();
        services.AddScoped<FluentValidation.IValidator<WinBeyazEsya.Application.DTOs.Definitions.WarehouseDto>, WinBeyazEsya.Application.Validators.Definitions.WarehouseValidator>();
        services.AddScoped<ITerminalService, TerminalManager>();
        services.AddScoped<IBranchService, BranchManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Security.IRoleService, WinBeyazEsya.Application.Services.Security.RoleManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Production.IRawMaterialService, WinBeyazEsya.Application.Services.Production.RawMaterialManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Security.IUserPermissionService, WinBeyazEsya.Application.Services.Security.UserPermissionManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.System.IExchangeRateService, WinBeyazEsya.Application.Services.Management.ExchangeRateManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Management.ITaxRateService, WinBeyazEsya.Application.Services.Management.TaxRateManager>();
        services.AddScoped<ISystemParameterService, SystemParameterManager>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Management.CodeTemplateDto>, WinBeyazEsya.Application.Validations.Management.CodeTemplateValidator>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Management.CodeLogDto>, WinBeyazEsya.Application.Validations.Management.CodeLogValidator>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Management.EmailParameterDto>, WinBeyazEsya.Application.Validations.Management.EmailParameterValidator>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Management.MaliyetParametreDto>, WinBeyazEsya.Application.Validations.Management.MaliyetParametreValidator>();
        services.AddScoped<IMaliyetParametreService, MaliyetParametreManager>();
        
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Purchasing.PurchaseOrderDto>, WinBeyazEsya.Application.Validations.Purchasing.PurchaseOrderValidator>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Purchasing.PurchaseOrderLineDto>, WinBeyazEsya.Application.Validations.Purchasing.PurchaseOrderLineValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Purchasing.IPurchaseOrderService, WinBeyazEsya.Application.Services.Purchasing.PurchaseOrderManager>();

        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Common.ItemBarcodeDto>, WinBeyazEsya.Application.Validations.Common.ItemBarcodeValidator>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Common.SpecialCodeDto>, WinBeyazEsya.Application.Validations.Common.SpecialCodeValidator>();









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













        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Definitions.GeneralExpenseDto>, WinBeyazEsya.Application.Validations.Definitions.GeneralExpenseValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Definitions.IGeneralExpenseService, WinBeyazEsya.Application.Services.Definitions.GeneralExpenseManager>();

        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Definitions.MetalSheetGroupDto>, WinBeyazEsya.Application.Validators.Definitions.MetalSheetGroupValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Definitions.IMetalSheetGroupService, WinBeyazEsya.Application.Services.Definitions.MetalSheetGroupManager>();
        services.AddTransient<IValidator<WinBeyazEsya.Application.DTOs.Definitions.FinishedGoodDto>, WinBeyazEsya.Application.Validators.Definitions.FinishedGoodValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Definitions.IFinishedGoodService, WinBeyazEsya.Application.Services.Definitions.FinishedGoodManager>();

        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Definitions.ElectricalElectronicGroupDto>, WinBeyazEsya.Application.Validators.Definitions.ElectricalElectronicGroupValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Definitions.IElectricalElectronicGroupService, WinBeyazEsya.Application.Services.Definitions.ElectricalElectronicGroupManager>();

        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Definitions.GasAndIgnitionGroupDto>, WinBeyazEsya.Application.Validators.Definitions.GasAndIgnitionGroupValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Definitions.IGasAndIgnitionGroupService, WinBeyazEsya.Application.Services.Definitions.GasAndIgnitionGroupManager>();

        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Definitions.PlasticAndVisualPartsGroupDto>, WinBeyazEsya.Application.Validators.Definitions.PlasticAndVisualPartsGroupValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Definitions.IPlasticAndVisualPartsGroupService, WinBeyazEsya.Application.Services.Definitions.PlasticAndVisualPartsGroupManager>();

        services.AddScoped<WinBeyazEsya.Application.Interfaces.Definitions.IChemicalAndInsulationGroupService, WinBeyazEsya.Application.Services.Definitions.ChemicalAndInsulationGroupManager>();
        services.AddTransient<IValidator<WinBeyazEsya.Application.DTOs.Definitions.ChemicalAndInsulationGroupDto>, WinBeyazEsya.Application.Validators.Definitions.ChemicalAndInsulationGroupValidator>();

        services.AddScoped<WinBeyazEsya.Application.Interfaces.Definitions.IMechanicalAndHardwareGroupService, WinBeyazEsya.Application.Services.Definitions.MechanicalAndHardwareGroupManager>();
        services.AddTransient<IValidator<WinBeyazEsya.Application.DTOs.Definitions.MechanicalAndHardwareGroupDto>, WinBeyazEsya.Application.Validators.Definitions.MechanicalAndHardwareGroupValidator>();

        services.AddScoped<WinBeyazEsya.Application.Interfaces.Definitions.IPackagingAndPrintingGroupService, WinBeyazEsya.Application.Services.Definitions.PackagingAndPrintingGroupManager>();
        services.AddTransient<IValidator<WinBeyazEsya.Application.DTOs.Definitions.PackagingAndPrintingGroupDto>, WinBeyazEsya.Application.Validators.Definitions.PackagingAndPrintingGroupValidator>();

        services.AddScoped<WinBeyazEsya.Application.Interfaces.Definitions.IWireAndGridGroupService, WinBeyazEsya.Application.Services.Definitions.WireAndGridGroupManager>();
        services.AddTransient<IValidator<WinBeyazEsya.Application.DTOs.Definitions.WireAndGridGroupDto>, WinBeyazEsya.Application.Validators.Definitions.WireAndGridGroupValidator>();

        services.AddScoped<WinBeyazEsya.Application.Interfaces.Definitions.IOtherMaterialGroupService, WinBeyazEsya.Application.Services.Definitions.OtherMaterialGroupManager>();
        services.AddTransient<IValidator<WinBeyazEsya.Application.DTOs.Definitions.OtherMaterialGroupDto>, WinBeyazEsya.Application.Validators.Definitions.OtherMaterialGroupValidator>();

        services.AddScoped<WinBeyazEsya.Application.Interfaces.Management.ISystemParameterService, WinBeyazEsya.Application.Services.Management.SystemParameterManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Updater.IAutoUpdateService, WinBeyazEsya.Application.Services.Updater.AutoUpdateManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Definitions.IProductRecipeService, WinBeyazEsya.Application.Services.Definitions.ProductRecipeManager>();
        services.AddTransient<IValidator<WinBeyazEsya.Application.DTOs.Definitions.ProductRecipeDto>, WinBeyazEsya.Application.Validators.Definitions.ProductRecipeValidator>();

        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Definitions.CountryDto>, WinBeyazEsya.Application.Validators.Definitions.CountryValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Definitions.ICountryService, WinBeyazEsya.Application.Services.Definitions.CountryManager>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Definitions.CityDto>, WinBeyazEsya.Application.Validators.Definitions.CityValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Definitions.ICityService, WinBeyazEsya.Application.Services.Definitions.CityManager>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Definitions.TownDto>, WinBeyazEsya.Application.Validators.Definitions.TownValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Definitions.ITownService, WinBeyazEsya.Application.Services.Definitions.TownManager>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Definitions.CurrentAccountDto>, WinBeyazEsya.Application.Validators.Definitions.CurrentAccountValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Definitions.ICurrentAccountService, WinBeyazEsya.Application.Services.Definitions.CurrentAccountManager>();

        return services;
    }
}

