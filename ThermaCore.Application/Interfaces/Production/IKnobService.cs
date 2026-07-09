using System.Collections.Generic;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Interfaces.Production;

public interface IKnobService
{
    KnobDto GetById(long id);
    IEnumerable<KnobListDto> GetAll();
    long Insert(KnobDto dto);
    void Update(KnobDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
