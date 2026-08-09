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

public class PlasticAndVisualPartsGroupManager : BaseManager<PlasticAndVisualPartsGroupListDto, PlasticAndVisualPartsGroupDto, PlasticAndVisualPartsGroup>, IPlasticAndVisualPartsGroupService
{
    public PlasticAndVisualPartsGroupManager(
        IMapper mapper, 
        IRepository<PlasticAndVisualPartsGroup> repository, 
        IUnitOfWork unitOfWork,
        IValidator<PlasticAndVisualPartsGroupDto>? validator = null) 
        : base(mapper, repository, unitOfWork, validator)
    {
    }
}

