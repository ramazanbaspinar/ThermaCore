using WinBeyazEsya.Application.Interfaces.Base;
using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface ICountryService : IBaseService
{
    CountryDto GetById(long id);
    IEnumerable<CountryDto> GetAll();
    long Insert(CountryDto dto);
    void Update(CountryDto dto);
    void Delete(long id);
}
