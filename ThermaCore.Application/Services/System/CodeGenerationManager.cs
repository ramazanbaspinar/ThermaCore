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
    private readonly IRepository<KodSablon> _kodSablonRepository;
    private readonly IKodLogRepository _kodLogRepository;
    private readonly ITenantDatabaseCrudService _tenantService;

    public CodeGenerationManager(IRepository<KodSablon> kodSablonRepository, IKodLogRepository kodLogRepository, ITenantDatabaseCrudService tenantService)
    {
        _kodSablonRepository = kodSablonRepository;
        _kodLogRepository = kodLogRepository;
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
        var kodKural = _kodSablonRepository.Find(x => x.Modul == request.Modul).FirstOrDefault();

        if (kodKural == null || !kodKural.OtomatikKodUretmeDurumu)
            return null!;

        string firmaKodu = "";
        string tarihStr = "";
        string tarihKey = "GENEL";

        if (kodKural.FirmaKisaKodKullanimDurumu && request.FirmaKisaKodKullanilsin && request.FirmaId > 0)
        {
            var tenant = _tenantService.GetById(request.FirmaId);
            if (tenant != null)
                firmaKodu = tenant.CompanyCode;
        }

        if (kodKural.TarihliKodUretmeDurumu)
        {
            tarihStr = GetFormattedDate(kodKural.TarihFormati);
            if (kodKural.TarihBazliKodSifrlamaDurumu)
                tarihKey = GetDateKey(kodKural.TarihFormati);
        }

        int sayi = 1;
        if (request.TestModu)
        {
            sayi = kodKural.BaslangicSayisi;
        }
        else
        {
            sayi = await _kodLogRepository.GetAndIncrementNextNumberAtomicAsync(request.Modul, firmaKodu, tarihKey, kodKural.BaslangicSayisi, request.BranchId);
        }

        string sayisalStr = sayi.ToString().PadLeft(kodKural.SayisalUzunluk, '0');

        var parcalar = new List<string>();
        if (!string.IsNullOrEmpty(kodKural.KodOnEk)) parcalar.Add(kodKural.KodOnEk);
        if (!string.IsNullOrEmpty(tarihStr)) parcalar.Add(tarihStr);
        if (!string.IsNullOrEmpty(firmaKodu)) parcalar.Add(firmaKodu);
        parcalar.Add(sayisalStr);
        if (!string.IsNullOrEmpty(kodKural.KodSonEk)) parcalar.Add(kodKural.KodSonEk);

        return new CodeGenerationResultDto
        {
            Code = string.Join("-", parcalar),
            KullaniciMudahaleEdilebilir = kodKural.KullaniciMudahalesiDurumu,
            FirmaKisaKodKullanildiMi = kodKural.FirmaKisaKodKullanimDurumu
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
