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

public class OtherMaterialGroupManager : BaseManager<OtherMaterialGroupListDto, OtherMaterialGroupDto, OtherMaterialGroup>, IOtherMaterialGroupService
{
    public OtherMaterialGroupManager(
        IMapper mapper, 
        IRepository<OtherMaterialGroup> repository, 
        IUnitOfWork unitOfWork,
        IValidator<OtherMaterialGroupDto>? validator = null) 
        : base(mapper, repository, unitOfWork, validator)
    {
    }

    public bool IsCodeUnique(long id, string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return true;
        return _repository.Find(x => x.Code == code && x.Id != id).FirstOrDefault() == null;
    }
}
