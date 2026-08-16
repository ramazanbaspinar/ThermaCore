using WinBeyazEsya.Application.Interfaces.Base;
using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface ICityService : IBaseService
{
    CityDto GetById(long id);
    IEnumerable<CityDto> GetAll();
    long Insert(CityDto dto);
    void Update(CityDto dto);
    void Delete(long id);
}
