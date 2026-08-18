using AutoMapper;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Application.Interfaces.Management;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Management;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.Services.Management;

public class TaxRateManager : BaseManager<TaxRateListDto, TaxRateDto, TaxRate>, ITaxRateService
{
    public TaxRateManager(
        IMapper mapper,
        IRepository<TaxRate> repository,
        IUnitOfWork unitOfWork,
        IValidator<TaxRateDto> validator)
        : base(mapper, repository, unitOfWork, validator)
    {
    }

    public IEnumerable<TaxRateListDto> GetByTaxType(TaxType taxType)
    {
        var entities = _repository.Find(x => x.TaxType == taxType).ToList();
        return _mapper.Map<IEnumerable<TaxRateListDto>>(entities);
    }
}

