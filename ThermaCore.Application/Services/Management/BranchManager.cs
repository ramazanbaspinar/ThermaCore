using AutoMapper;
using FluentValidation;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Services.Base;
using ThermaCore.Domain.Entities.Management;

namespace ThermaCore.Application.Services.Management;

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
