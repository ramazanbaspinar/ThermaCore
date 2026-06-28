using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Services.Base;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.Services.Management;

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
