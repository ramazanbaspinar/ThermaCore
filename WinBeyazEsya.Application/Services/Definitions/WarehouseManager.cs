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

public class WarehouseManager : BaseManager<WarehouseListDto, WarehouseDto, Warehouse>, IWarehouseService
{
    public WarehouseManager(
        IMapper mapper, 
        IRepository<Warehouse> repository, 
        IUnitOfWork unitOfWork,
        IValidator<WarehouseDto>? validator = null) 
        : base(mapper, repository, unitOfWork, validator)
    {
    }
}
