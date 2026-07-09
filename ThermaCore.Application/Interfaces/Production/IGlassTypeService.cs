using System.Collections.Generic;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Interfaces.Production;

public interface IGlassTypeService
{
    GlassTypeDto GetById(long id);
    IEnumerable<GlassTypeListDto> GetAll();
    long Insert(GlassTypeDto dto);
    void Update(GlassTypeDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
