using AutoMapper;
using System.Linq;
using FluentValidation;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Application.Interfaces.Definitions;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Services.Base;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Application.Services.Definitions;

public class HandleManager : BaseManager<HandleListDto, HandleDto, Handle>, IHandleService
{
    public HandleManager(
        IMapper mapper,
        IRepository<Handle> repository,
        IUnitOfWork unitOfWork,
        IValidator<HandleDto> validator) : base(mapper, repository, unitOfWork, validator)
    {
    }
}
