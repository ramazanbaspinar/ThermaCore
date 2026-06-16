using System.Collections.Generic;
using ThermaCore.Application.DTOs.Yonetim;

namespace ThermaCore.Application.Services.Yonetim;

public interface ITerminalService
{
    TerminalDto GetById(long id);
    IEnumerable<TerminalListDto> GetAll();
    long Insert(TerminalDto dto);
    void Update(TerminalDto dto);
    void Delete(long id);

    TerminalDto GetTerminalByMacAddress(string macAddress);
}
