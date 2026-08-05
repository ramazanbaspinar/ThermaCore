using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Interfaces.Production;

public interface IValveService
{
    ValveDto GetById(long id);
    IEnumerable<ValveListDto> GetAll();
    long Insert(ValveDto dto);
    void Update(ValveDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}

