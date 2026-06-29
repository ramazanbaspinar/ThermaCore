using System.Collections.Generic;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Interfaces.Production;

public interface IQualityStandardService
{
    QualityStandardDto GetById(long id);
    IEnumerable<QualityStandardListDto> GetAll();
    long Insert(QualityStandardDto dto);
    void Update(QualityStandardDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
