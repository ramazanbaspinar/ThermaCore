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

public class ChemicalAndInsulationGroupManager : BaseManager<ChemicalAndInsulationGroupListDto, ChemicalAndInsulationGroupDto, ChemicalAndInsulationGroup>, IChemicalAndInsulationGroupService
{
    public ChemicalAndInsulationGroupManager(
        IMapper mapper, 
        IRepository<ChemicalAndInsulationGroup> repository, 
        IUnitOfWork unitOfWork,
        IValidator<ChemicalAndInsulationGroupDto>? validator = null) 
        : base(mapper, repository, unitOfWork, validator)
    {
    }

    public bool IsCodeUnique(string code, long id = 0)
    {
        if (string.IsNullOrWhiteSpace(code)) return true;
        return _repository.Find(x => x.Code == code && x.Id != id).FirstOrDefault() == null;
    }
}
