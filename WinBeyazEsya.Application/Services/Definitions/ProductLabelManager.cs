using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Services.Definitions;

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

