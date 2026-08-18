using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Base;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface ICountryService : IBaseService
{
    CountryDto GetById(long id);
    IEnumerable<CountryDto> GetAll();
    long Insert(CountryDto dto);
    void Update(CountryDto dto);
    void Delete(long id);
}
