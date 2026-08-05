using AutoMapper;
using System.Linq;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Services.Definitions;

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

