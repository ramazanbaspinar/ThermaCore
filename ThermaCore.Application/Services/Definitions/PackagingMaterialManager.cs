using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Application.Interfaces.Definitions;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Services.Base;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Application.Services.Definitions;

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
