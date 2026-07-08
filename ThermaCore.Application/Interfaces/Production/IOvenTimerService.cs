using System.Collections.Generic;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Interfaces.Production;

public interface IOvenTimerService
{
    OvenTimerDto GetById(long id);
    IEnumerable<OvenTimerListDto> GetAll();
    long Insert(OvenTimerDto dto);
    void Update(OvenTimerDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
