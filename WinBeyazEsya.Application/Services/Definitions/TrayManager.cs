using AutoMapper;
using System.Linq;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Services.Definitions;

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

