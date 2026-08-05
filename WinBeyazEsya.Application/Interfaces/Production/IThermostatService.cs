using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Interfaces.Production;

public interface IThermostatService
{
    ThermostatDto GetById(long id);
    IEnumerable<ThermostatListDto> GetAll();
    long Insert(ThermostatDto dto);
    void Update(ThermostatDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}

