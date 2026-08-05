using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Services.Definitions;

public class PackagingMaterialManager : BaseManager<PackagingMaterialListDto, PackagingMaterialDto, PackagingMaterial>, IPackagingMaterialService
{
    public PackagingMaterialManager(
        IMapper mapper,
        IRepository<PackagingMaterial> repository,
        IUnitOfWork unitOfWork,
        IValidator<PackagingMaterialDto> validator) : base(mapper, repository, unitOfWork, validator)
    {
    }

    public override IEnumerable<PackagingMaterialListDto> GetAll()
    {
        return AutoMapper.QueryableExtensions.Extensions.ProjectTo<PackagingMaterialListDto>(_repository.GetAll(), _mapper.ConfigurationProvider).ToList();
    }
}

