using System;
using System.Linq;
using AutoMapper;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Services.Definitions;

public class PackagingAndPrintingGroupManager : BaseManager<PackagingAndPrintingGroupListDto, PackagingAndPrintingGroupDto, PackagingAndPrintingGroup>, IPackagingAndPrintingGroupService
{
    public PackagingAndPrintingGroupManager(
        IMapper mapper, 
        IRepository<PackagingAndPrintingGroup> repository, 
        IUnitOfWork unitOfWork,
        IValidator<PackagingAndPrintingGroupDto>? validator = null) 
        : base(mapper, repository, unitOfWork, validator)
    {
    }

    public bool IsCodeUnique(long id, string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return true;
        return _repository.Find(x => x.Code == code && x.Id != id).FirstOrDefault() == null;
    }
}
