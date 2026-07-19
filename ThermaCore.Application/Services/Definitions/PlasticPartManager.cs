using AutoMapper;
using FluentValidation;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Application.Interfaces.Definitions;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Services.Base;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Application.Services.Definitions
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
