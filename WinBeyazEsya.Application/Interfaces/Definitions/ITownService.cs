using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Base;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface ITownService : IBaseService
{
    TownDto GetById(long id);
    IEnumerable<TownDto> GetAll();
    long Insert(TownDto dto);
    void Update(TownDto dto);
    void Delete(long id);
}
