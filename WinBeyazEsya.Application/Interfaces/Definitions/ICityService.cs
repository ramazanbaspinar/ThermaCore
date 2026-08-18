using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Base;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface ICityService : IBaseService
{
    CityDto GetById(long id);
    IEnumerable<CityDto> GetAll();
    long Insert(CityDto dto);
    void Update(CityDto dto);
    void Delete(long id);
}
