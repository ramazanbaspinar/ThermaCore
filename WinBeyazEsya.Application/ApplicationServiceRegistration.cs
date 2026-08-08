using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Application.Services.Management;
using WinBeyazEsya.Application.Interfaces.Management;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Services.Definitions;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // AutoMapper ve FluentValidation kay�tlar�
        services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssemblyContaining<WinBeyazEsya.Application.Validations.Definitions.UnitValidator>();
        ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("tr-TR");

        // Manager (Service) S�n�flar�n�n Kay�tlar�
        services.AddScoped<IUnitConversionService, UnitConversionManager>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Definitions.UnitConversionDto>, WinBeyazEsya.Application.Validations.Definitions.UnitConversionValidator>();
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IUserFavoriteService, UserFavoriteManager>();
        services.AddScoped<ITerminalService, TerminalManager>();
        services.AddScoped<IBranchService, BranchManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Security.IRoleService, WinBeyazEsya.Application.Services.Security.RoleManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Security.IUserPermissionService, WinBeyazEsya.Application.Services.Security.UserPermissionManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.System.IExchangeRateService, WinBeyazEsya.Application.Services.Management.ExchangeRateManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Management.ITaxRateService, WinBeyazEsya.Application.Services.Management.TaxRateManager>();
        services.AddScoped<ISystemParameterService, SystemParameterManager>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Management.CodeTemplateDto>, WinBeyazEsya.Application.Validations.Management.CodeTemplateValidator>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Management.CodeLogDto>, WinBeyazEsya.Application.Validations.Management.CodeLogValidator>();
        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Management.MaliyetParametreDto>, WinBeyazEsya.Application.Validations.Management.MaliyetParametreValidator>();
        services.AddScoped<IMaliyetParametreService, MaliyetParametreManager>();

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

        services.AddScoped<IValidator<WinBeyazEsya.Application.DTOs.Definitions.ElectricalElectronicGroupDto>, WinBeyazEsya.Application.Validators.Definitions.ElectricalElectronicGroupValidator>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Definitions.IElectricalElectronicGroupService, WinBeyazEsya.Application.Services.Definitions.ElectricalElectronicGroupManager>();
        
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Management.ISystemParameterService, WinBeyazEsya.Application.Services.Management.SystemParameterManager>();
        services.AddScoped<WinBeyazEsya.Application.Interfaces.Updater.IAutoUpdateService, WinBeyazEsya.Application.Services.Updater.AutoUpdateManager>();        
        return services;
    }
}

