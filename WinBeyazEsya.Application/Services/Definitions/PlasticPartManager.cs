using AutoMapper;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Services.Definitions
{
    public class PlasticPartManager : BaseManager<PlasticPartListDto, PlasticPartDto, PlasticPart>, IPlasticPartService
    {
        public PlasticPartManager(
            IMapper mapper,
            IRepository<PlasticPart> repository,
            IUnitOfWork unitOfWork,
            IValidator<PlasticPartDto> validator) : base(mapper, repository, unitOfWork, validator)
        {
        }
    }
}

