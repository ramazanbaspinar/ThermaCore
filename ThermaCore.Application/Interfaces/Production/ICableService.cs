using System.Collections.Generic;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Interfaces.Production;

public interface ICableService
{
    CableDto GetById(long id);
    IEnumerable<CableListDto> GetAll();
    long Insert(CableDto dto);
    void Update(CableDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
