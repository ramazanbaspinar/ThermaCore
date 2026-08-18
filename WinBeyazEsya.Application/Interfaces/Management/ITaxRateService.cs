using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.Interfaces.Management;

public interface ITaxRateService
{
    TaxRateDto GetById(long id);
    IEnumerable<TaxRateListDto> GetAll();
    IEnumerable<TaxRateListDto> GetByTaxType(TaxType taxType);
    long Insert(TaxRateDto dto);
    void Update(TaxRateDto dto);
    void Delete(long id);
}

