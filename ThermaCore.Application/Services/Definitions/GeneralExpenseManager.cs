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
    public class GeneralExpenseManager : BaseManager<GeneralExpenseListDto, GeneralExpenseDto, GeneralExpense>, IGeneralExpenseService
    {
        public GeneralExpenseManager(
            IMapper mapper,
            IRepository<GeneralExpense> repository,
            IUnitOfWork unitOfWork,
            IValidator<GeneralExpenseDto> validator) : base(mapper, repository, unitOfWork, validator)
        {
        }

        public override IEnumerable<GeneralExpenseListDto> GetAll()
        {
            return AutoMapper.QueryableExtensions.Extensions.ProjectTo<GeneralExpenseListDto>(_repository.GetAll(), _mapper.ConfigurationProvider).ToList();
        }

        public bool IsCodeUnique(long id, string code)
        {
            if (string.IsNullOrWhiteSpace(code)) return true;
            return !_repository.Find(x => x.Code == code && x.Id != id).Any();
        }
    }
}
