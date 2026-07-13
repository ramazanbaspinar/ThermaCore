using System.Collections.Generic;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Interfaces.Production;

public interface IGasValveService
{
    GasValveDto GetById(long id);
    IEnumerable<GasValveListDto> GetAll();
    long Insert(GasValveDto dto);
    void Update(GasValveDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
