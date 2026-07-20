using AutoMapper;
using FluentValidation;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Application.Interfaces.Definitions;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Services.Base;
using ThermaCore.Domain.Entities.Definitions;
using System.Linq;
using System.Collections.Generic;

namespace ThermaCore.Application.Services.Definitions
{
    public class FastenerManager : BaseManager<FastenerListDto, FastenerDto, Fastener>, IFastenerService
    {
        public FastenerManager(
            IMapper mapper,
            IRepository<Fastener> repository,
            IUnitOfWork unitOfWork,
            IValidator<FastenerDto> validator) : base(mapper, repository, unitOfWork, validator)
        {
        }

        public override IEnumerable<FastenerListDto> GetAll()
        {
            return AutoMapper.QueryableExtensions.Extensions.ProjectTo<FastenerListDto>(_repository.GetAll(), _mapper.ConfigurationProvider).ToList();
        }
    }
}
