using System.Collections.Generic;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Interfaces.Production;

public interface IOvenGlassService
{
    OvenGlassDto GetById(long id);
    IEnumerable<OvenGlassListDto> GetAll();
    long Insert(OvenGlassDto dto);
    void Update(OvenGlassDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
