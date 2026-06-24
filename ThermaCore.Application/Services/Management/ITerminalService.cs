using System.Collections.Generic;
using ThermaCore.Application.DTOs.Management;

namespace ThermaCore.Application.Services.Management;

public interface ITerminalService
{
    TerminalDto GetById(long id);
    IEnumerable<TerminalListDto> GetAll();
    long Insert(TerminalDto dto);
    void Update(TerminalDto dto);
    void Delete(long id);

    TerminalDto? GetTerminalByHardwareId(string hwid);
}
