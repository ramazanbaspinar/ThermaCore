using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Interfaces.Production;

public interface IGasValveService
{
    GasValveDto GetById(long id);
    IEnumerable<GasValveListDto> GetAll();
    long Insert(GasValveDto dto);
    void Update(GasValveDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}

