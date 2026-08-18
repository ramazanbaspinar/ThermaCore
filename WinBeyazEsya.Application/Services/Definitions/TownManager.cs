using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Interfaces.System;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Services.Definitions;

public class TownManager : BaseManager<TownDto, TownDto, Town>, ITownService
{
    private readonly ICodeGenerationService _codeGenerationService;

    public TownManager(
        IMapper mapper,
        IRepository<Town> repository,
        IUnitOfWork unitOfWork,
        ICodeGenerationService codeGenerationService)
        : base(mapper, repository, unitOfWork, null)
    {
        _codeGenerationService = codeGenerationService;
    }

    private void GenerateCodeIfRequired(TownDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Code) || dto.Code == "Yeni Kod" || dto.Code == "< Otomatik Üretilecek >")
        {
            var req = new WinBeyazEsya.Application.DTOs.Management.CodeGenerationRequestDto
            {
                Modul = WinBeyazEsya.Domain.Enums.ModuleType.Town,
                FirmaId = 0,
                FirmaKisaKodKullanilsin = false,
                ShortCode = ""
            };

            var generatedCodeResponse = _codeGenerationService.GetNewCodeAsync(req).GetAwaiter().GetResult();
            if (generatedCodeResponse != null && !string.IsNullOrEmpty(generatedCodeResponse.Code))
            {
                dto.Code = generatedCodeResponse.Code;
            }
        }
    }

    public override long Insert(TownDto dto)
    {
        GenerateCodeIfRequired(dto);
        return base.Insert(dto);
    }

    public override void Update(TownDto dto)
    {
        GenerateCodeIfRequired(dto);
        base.Update(dto);
    }
}
