using AutoMapper;
using System.Linq;
using FluentValidation;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Application.Interfaces.Definitions;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Services.Base;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Application.Services.Definitions;

public class TrayManager : BaseManager<TrayListDto, TrayDto, Tray>, ITrayService
{
    public TrayManager(
        IMapper mapper,
        IRepository<Tray> repository,
        IUnitOfWork unitOfWork,
        IValidator<TrayDto> validator) : base(mapper, repository, unitOfWork, validator)
    {
    }

    public bool IsCodeUnique(long id, string code)
    {
        var existing = _repository.GetAll().FirstOrDefault(x => x.Code == code);
        return existing == null || existing.Id == id;
    }
}
