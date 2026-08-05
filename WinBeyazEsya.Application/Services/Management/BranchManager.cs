using AutoMapper;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Management;

namespace WinBeyazEsya.Application.Services.Management;

public class BranchManager : BaseMasterManager<BranchDto, BranchDto, Branch>, IBranchService
{
    public BranchManager(
        IMapper mapper, 
        IMasterRepository<Branch> repository, 
        IMasterUnitOfWork unitOfWork, 
        IValidator<BranchDto> validator) 
        : base(mapper, repository, unitOfWork, validator)
    {
    }

    public IEnumerable<BranchDto> GetActiveBranches()
    {
        var entities = _repository.Find(x => !x.IsDeleted && x.IsActive).ToList();
        return _mapper.Map<IEnumerable<BranchDto>>(entities);
    }
}

