using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IGasketService
{
    IEnumerable<GasketListDto> GetAll();
    GasketDto GetById(long id);
    long Insert(GasketDto dto);
    void Update(GasketDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}

