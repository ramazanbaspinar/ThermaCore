using AutoMapper;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Definitions;
using System.Linq;
using System.Collections.Generic;

namespace WinBeyazEsya.Application.Services.Definitions
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

