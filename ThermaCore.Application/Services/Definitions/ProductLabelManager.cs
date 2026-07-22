using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Application.Interfaces.Definitions;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Services.Base;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Application.Services.Definitions;

public class ProductLabelManager : BaseManager<ProductLabelListDto, ProductLabelDto, ProductLabel>, IProductLabelService
{
    public ProductLabelManager(
        IMapper mapper, 
        IRepository<ProductLabel> repository, 
        IUnitOfWork unitOfWork,
        IValidator<ProductLabelDto> validator) 
        : base(mapper, repository, unitOfWork, validator)
    {
    }

    public override IEnumerable<ProductLabelListDto> GetAll()
    {
        return _repository.GetAll()
            .ProjectTo<ProductLabelListDto>(_mapper.ConfigurationProvider)
            .ToList();
    }
}
