using System.Collections.Generic;
using ThermaCore.Application.DTOs.Definitions;

namespace ThermaCore.Application.Interfaces.Definitions;

public interface ITrayService
{
    IEnumerable<TrayListDto> GetAll();
    TrayDto GetById(long id);
    long Insert(TrayDto dto);
    void Update(TrayDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
