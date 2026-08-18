using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IUnitConversionService
{
    UnitConversionDto GetById(long id);
    IEnumerable<UnitConversionListDto> GetByEntityId(long entityId);
    void SaveChanges(long entityId, IEnumerable<UnitConversionDto> conversions);
}


