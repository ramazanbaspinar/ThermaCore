using System.Linq;
using AutoMapper;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Management;

namespace WinBeyazEsya.Application.Services.Management;

public class TerminalManager : BaseMasterManager<TerminalListDto, TerminalDto, Terminal>, ITerminalService
{
    private readonly IMasterRepository<SystemLicense> _licenseRepository;

    public TerminalManager(
        IMapper mapper, 
        IMasterRepository<Terminal> repository, 
        IMasterUnitOfWork unitOfWork, 
        IMasterRepository<SystemLicense> licenseRepository,
        IValidator<TerminalDto>? validator = null) 
        : base(mapper, repository, unitOfWork, validator)
    {
        _licenseRepository = licenseRepository;
    }

    public TerminalDto? GetTerminalByHardwareId(string hwid)
    {
        var terminal = _repository.Find(x => x.HardwareId == hwid && x.IsActive).FirstOrDefault();
        return _mapper.Map<TerminalDto>(terminal);
    }

    public override void Update(TerminalDto dto)
    {
        if (dto.IsActive)
        {
            var existingEntity = _repository.GetById(dto.Id);
            if (existingEntity != null && !existingEntity.IsActive) // Pasif'ten Aktif'e geçiş varsa kontrol et
            {
                var license = _licenseRepository.Find(x => true).FirstOrDefault();
                int maxTerminalCount = license?.MaxTerminalCount ?? 0;
                
                // Zaten aktif olanların sayısı
                var activeTerminalsCount = _repository.Find(t => t.IsActive).Count();

                if (activeTerminalsCount >= maxTerminalCount)
                {
                    string errorMessage = $@"Mevcut Lisansınızın izin verdiği maksimum {maxTerminalCount} aktif terminal (cihaz) sınırına ulaştınız!
Yeni bir cihazı aktife alabilmek için lütfen kullanımda olmayan mevcut bir cihazı pasife çekiniz.

Daha fazla terminal (cihaz) lisansı satın almak için lütfen iletişime geçiniz:
Ramazan BAŞPINAR
ramazanbaspinar2@gmail.com
0530 785 3103";
                    
                    var failure = new FluentValidation.Results.ValidationFailure("Lisans", errorMessage);
                    throw new FluentValidation.ValidationException(new global::System.Collections.Generic.List<FluentValidation.Results.ValidationFailure> { failure });
                }
            }
        }

        base.Update(dto);
    }
}

