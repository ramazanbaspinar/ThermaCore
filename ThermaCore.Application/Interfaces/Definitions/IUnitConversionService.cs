using System;
using System.Collections.Generic;
using ThermaCore.Application.DTOs.Definitions;

namespace ThermaCore.Application.Interfaces.Definitions;

public interface IUnitConversionService
{
    UnitConversionDto GetById(long id);
    IEnumerable<UnitConversionListDto> GetByEntityId(Guid entityId);
    void SaveChanges(Guid entityId, IEnumerable<UnitConversionDto> conversions);
}
