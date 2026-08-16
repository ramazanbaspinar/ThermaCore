using System.Linq;
using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Interfaces.System;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Services.Definitions;

public class CurrentAccountManager : BaseManager<CurrentAccountDto, CurrentAccountDto, CurrentAccount>, ICurrentAccountService
{
    private readonly ICodeGenerationService _codeGenerationService;

    public CurrentAccountManager(
        IMapper mapper, 
        IRepository<CurrentAccount> repository, 
        IUnitOfWork unitOfWork,
        ICodeGenerationService codeGenerationService) 
        : base(mapper, repository, unitOfWork, null)
    {
        _codeGenerationService = codeGenerationService;
    }

    private void GenerateCodeIfRequired(CurrentAccountDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Code) || dto.Code == "Yeni Kod" || dto.Code == "< Otomatik Üretilecek >")
        {
            var req = new CodeGenerationRequestDto
            {
                Modul = WinBeyazEsya.Domain.Enums.ModuleType.CurrentAccount,
                FirmaId = 0,
                FirmaKisaKodKullanilsin = true,
                ShortCode = dto.ShortCode
            };
            
            var generatedCodeResponse = _codeGenerationService.GetNewCodeAsync(req).GetAwaiter().GetResult();
            if (generatedCodeResponse != null && !string.IsNullOrEmpty(generatedCodeResponse.Code))
            {
                dto.Code = generatedCodeResponse.Code;
            }
        }
    }

    public override long Insert(CurrentAccountDto dto)
    {
        GenerateCodeIfRequired(dto);
        return base.Insert(dto);
    }

    public override void Update(CurrentAccountDto dto)
    {
        GenerateCodeIfRequired(dto);
        base.Update(dto);
    }
}

