using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Interfaces.Production;

public interface IKnobService
{
    KnobDto GetById(long id);
    IEnumerable<KnobListDto> GetAll();
    long Insert(KnobDto dto);
    void Update(KnobDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}

