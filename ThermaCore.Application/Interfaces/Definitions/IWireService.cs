using System.Collections.Generic;
using ThermaCore.Application.DTOs.Definitions;

namespace ThermaCore.Application.Interfaces.Definitions;

public interface IWireService
{
    IEnumerable<WireListDto> GetAll();
    WireDto GetById(long id);
    long Insert(WireDto dto);
    void Update(WireDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
