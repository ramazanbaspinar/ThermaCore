using System.Linq;
using AutoMapper;
using FluentValidation;
using ThermaCore.Application.DTOs.Yonetim;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Services.Base;
using ThermaCore.Domain.Entities.Yonetim;

namespace ThermaCore.Application.Services.Yonetim;

public class TerminalManager : BaseManager<TerminalDto, Terminal>, ITerminalService
{
    public TerminalManager(
        IMapper mapper, 
        IRepository<Terminal> repository, 
        IUnitOfWork unitOfWork, 
        IValidator<TerminalDto> validator) 
        : base(mapper, repository, unitOfWork, validator)
    {
    }

    public TerminalDto GetTerminalByMacAddress(string macAddress)
    {
        var terminal = _repository.Find(x => x.MacAdresi == macAddress && x.Durum).FirstOrDefault();
        return _mapper.Map<TerminalDto>(terminal);
    }
}
