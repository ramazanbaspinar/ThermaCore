using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IWireService
{
    IEnumerable<WireListDto> GetAll();
    WireDto GetById(long id);
    long Insert(WireDto dto);
    void Update(WireDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}

