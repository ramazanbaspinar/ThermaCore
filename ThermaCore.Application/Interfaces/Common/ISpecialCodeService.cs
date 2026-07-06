using System.Collections.Generic;
using ThermaCore.Application.DTOs.Common;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.Interfaces.Common;

public interface ISpecialCodeService
{
    List<SpecialCodeDto> GetCodes(SpecialCodeType codeType, string entityType);
    SpecialCodeDto GetById(long id);
    long Insert(SpecialCodeDto dto);
    void Update(SpecialCodeDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, SpecialCodeType codeType, string entityType, string code);
}
