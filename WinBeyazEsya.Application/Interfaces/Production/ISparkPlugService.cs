using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Interfaces.Production;

public interface ISparkPlugService
{
    SparkPlugDto GetById(long id);
    IEnumerable<SparkPlugListDto> GetAll();
    long Insert(SparkPlugDto dto);
    void Update(SparkPlugDto dto);
    void Delete(long id);

    bool IsCodeUnique(long id, string code);
}

