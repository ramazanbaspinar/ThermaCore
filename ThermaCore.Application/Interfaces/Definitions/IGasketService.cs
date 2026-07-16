using System.Collections.Generic;
using ThermaCore.Application.DTOs.Definitions;

namespace ThermaCore.Application.Interfaces.Definitions;

public interface IGasketService
{
    IEnumerable<GasketListDto> GetAll();
    GasketDto GetById(long id);
    long Insert(GasketDto dto);
    void Update(GasketDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
