using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Interfaces.Production;

public interface IQualityStandardService
{
    QualityStandardDto GetById(long id);
    IEnumerable<QualityStandardListDto> GetAll();
    long Insert(QualityStandardDto dto);
    void Update(QualityStandardDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}

