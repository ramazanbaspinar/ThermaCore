using System.Collections.Generic;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Interfaces.Production;

public interface IOvenFanService
{
    OvenFanDto GetById(long id);
    IEnumerable<OvenFanListDto> GetAllList();
    IEnumerable<OvenFanListDto> GetActiveList();
    long Insert(OvenFanDto dto);
    void Update(OvenFanDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
