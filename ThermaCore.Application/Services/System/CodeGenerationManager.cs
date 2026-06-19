using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Interfaces.System;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.Services.System;

public class CodeGenerationManager : ICodeGenerationService
{
    private readonly IRepository<CodeTemplate> _CodeTemplateRepository;
    private readonly ICodeLogRepository _CodeLogRepository;
    private readonly ITenantDatabaseCrudService _tenantService;

    public CodeGenerationManager(IRepository<CodeTemplate> CodeTemplateRepository, ICodeLogRepository CodeLogRepository, ITenantDatabaseCrudService tenantService)
    {
        _CodeTemplateRepository = CodeTemplateRepository;
        _CodeLogRepository = CodeLogRepository;
        _tenantService = tenantService;
    }

    public async Task<string> GetNewCodeAsync(ModuleType modul, long firmaId = 0)
    {
        var request = new CodeGenerationRequestDto
        {
            Modul = modul,
            FirmaId = firmaId,
            FirmaKisaKodKullanilsin = true
        };
        var result = await GetNewCodeAsync(request);
        return result?.Code ?? string.Empty;
    }

    public async Task<CodeGenerationResultDto> GetNewCodeAsync(CodeGenerationRequestDto request)
    {
        var kodKural = _CodeTemplateRepository.Find(x => x.Module == request.Modul).FirstOrDefault();

        if (kodKural == null || !kodKural.IsAutoCodeGenerationEnabled)
            return null!;

        string firmaKodu = "";
        string tarihStr = "";
        string tarihKey = "GENEL";

        if (kodKural.IsCompanyShortCodeUsed && request.FirmaKisaKodKullanilsin && request.FirmaId > 0)
        {
            // TODO: İleride Cari Kartlar eklendiğinde, `FirmaId` aslında CariKart Id'si olarak kullanılacak
            // ve Cari'nin Kısa Kodu (CompanyCode vb.) veritabanından çekilerek buraya eklenecektir.
            // Şimdilik boş bırakıyoruz.
            // var cariKart = _cariKartService.GetById(request.FirmaId);
            // if (cariKart != null) firmaKodu = cariKart.KisaKod;
        }

        if (kodKural.IsDateBasedCodeGenerationEnabled)
        {
            tarihStr = GetFormattedDate(kodKural.DateFormat);
            if (kodKural.IsDateBasedCodeResetEnabled)
                tarihKey = GetDateKey(kodKural.DateFormat);
        }

        int sayi = 1;
        if (request.TestModu)
        {
            sayi = kodKural.StartNumber;
        }
        else
        {
            sayi = await _CodeLogRepository.GetAndIncrementNextNumberAtomicAsync(request.Modul, firmaKodu, tarihKey, kodKural.StartNumber, request.BranchId);
        }

        string sayisalStr = sayi.ToString().PadLeft(kodKural.NumericLength, '0');

        var parcalar = new List<string>();
        if (!string.IsNullOrEmpty(kodKural.CodePrefix)) parcalar.Add(kodKural.CodePrefix);
        if (!string.IsNullOrEmpty(tarihStr)) parcalar.Add(tarihStr);
        if (!string.IsNullOrEmpty(firmaKodu)) parcalar.Add(firmaKodu);
        parcalar.Add(sayisalStr);
        if (!string.IsNullOrEmpty(kodKural.CodeSuffix)) parcalar.Add(kodKural.CodeSuffix);

        return new CodeGenerationResultDto
        {
            Code = string.Join("-", parcalar),
            KullaniciMudahaleEdilebilir = kodKural.IsUserInterventionAllowed,
            FirmaKisaKodKullanildiMi = kodKural.IsCompanyShortCodeUsed
        };
    }

    public async Task SaveCodeAsync(ModuleType modul, long firmaId, string generatedCode, long? branchId = null)
    {
        await Task.CompletedTask;
    }

    private string GetFormattedDate(DateFormat format)
    {
        return format switch
        {
            DateFormat.yyyy => DateTime.Today.ToString("yyyy"),
            DateFormat.yy => DateTime.Today.ToString("yy"),
            DateFormat.yyMM => DateTime.Today.ToString("yyMM"),
            DateFormat.yyyyMM => DateTime.Today.ToString("yyyyMM"),
            DateFormat.yyMMdd => DateTime.Today.ToString("yyMMdd"),
            DateFormat.yyyyMMdd => DateTime.Today.ToString("yyyyMMdd"),
            DateFormat.MMdd => DateTime.Today.ToString("MMdd"),
            DateFormat.MMyy => DateTime.Today.ToString("MMyy"),
            _ => ""
        };
    }

    private string GetDateKey(DateFormat format)
    {
        return format switch
        {
            DateFormat.yyyy => DateTime.Today.ToString("yyyy"),
            DateFormat.yy => DateTime.Today.ToString("yy"),
            DateFormat.yyMM => DateTime.Today.ToString("yyMM"),
            DateFormat.yyyyMM => DateTime.Today.ToString("yyyyMM"),
            DateFormat.yyMMdd => DateTime.Today.ToString("yyMMdd"),
            DateFormat.yyyyMMdd => DateTime.Today.ToString("yyyyMMdd"),
            DateFormat.MMdd => DateTime.Today.ToString("MMdd"),
            DateFormat.MMyy => DateTime.Today.ToString("MMyy"),
            _ => "GENEL"
        };
    }
}
