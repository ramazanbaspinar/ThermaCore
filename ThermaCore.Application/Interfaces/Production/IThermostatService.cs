using System.Collections.Generic;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Interfaces.Production;

public interface IThermostatService
{
    ThermostatDto GetById(long id);
    IEnumerable<ThermostatListDto> GetAll();
    long Insert(ThermostatDto dto);
    void Update(ThermostatDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
