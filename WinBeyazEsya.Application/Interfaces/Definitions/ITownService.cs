using WinBeyazEsya.Application.Interfaces.Base;
using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface ITownService : IBaseService
{
    TownDto GetById(long id);
    IEnumerable<TownDto> GetAll();
    long Insert(TownDto dto);
    void Update(TownDto dto);
    void Delete(long id);
}
