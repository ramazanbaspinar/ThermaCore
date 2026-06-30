using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Application.Interfaces.Production;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Services.Base;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Services.Production;

public class SurfaceTypeManager : BaseManager<SurfaceTypeListDto, SurfaceTypeDto, SurfaceType>, ISurfaceTypeService
{
    public SurfaceTypeManager(
        IMapper mapper,
        IRepository<SurfaceType> repository,
        IUnitOfWork unitOfWork,
        IValidator<SurfaceTypeDto> validator)
        : base(mapper, repository, unitOfWork, validator)
    {
    }

    public bool IsCodeUnique(long id, string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return true;
        return !global::System.Linq.Enumerable.Any(_repository.Find(x => x.Code.ToLower() == code.ToLower() && x.Id != id));
    }
}
