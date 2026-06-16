using System.Linq;
using AutoMapper;
using FluentValidation;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Services.Base;
using ThermaCore.Domain.Entities.Management;

namespace ThermaCore.Application.Services.Management;

public class TerminalManager : BaseMasterManager<TerminalListDto, TerminalDto, Terminal>, ITerminalService
{
    public TerminalManager(
        IMapper mapper, 
        IMasterRepository<Terminal> repository, 
        IMasterUnitOfWork unitOfWork, 
        IValidator<TerminalDto> validator) 
        : base(mapper, repository, unitOfWork, validator)
    {
    }

    public TerminalDto? GetTerminalByMacAddress(string macAddress)
    {
        var terminal = _repository.Find(x => x.MacAddress == macAddress && x.IsActive).FirstOrDefault();
        return _mapper.Map<TerminalDto>(terminal);
    }
}
