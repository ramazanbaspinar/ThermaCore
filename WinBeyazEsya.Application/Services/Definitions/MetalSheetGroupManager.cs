using AutoMapper;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Services.Definitions;

public class MetalSheetGroupManager : BaseManager<MetalSheetGroupListDto, MetalSheetGroupDto, MetalSheetGroup>, IMetalSheetGroupService
{
    public MetalSheetGroupManager(
        IMapper mapper,
        IRepository<MetalSheetGroup> repository,
        IUnitOfWork unitOfWork,
        IValidator<MetalSheetGroupDto>? validator = null)
        : base(mapper, repository, unitOfWork, validator)
    {
    }
}

