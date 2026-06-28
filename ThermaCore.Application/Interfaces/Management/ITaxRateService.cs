using System.Collections.Generic;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.Interfaces.Management;

public interface ITaxRateService
{
    TaxRateDto GetById(long id);
    IEnumerable<TaxRateListDto> GetAll();
    IEnumerable<TaxRateListDto> GetByTaxType(TaxType taxType);
    long Insert(TaxRateDto dto);
    void Update(TaxRateDto dto);
    void Delete(long id);
}
