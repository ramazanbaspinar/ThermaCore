using AutoMapper;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Services.Definitions
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
    }
}


