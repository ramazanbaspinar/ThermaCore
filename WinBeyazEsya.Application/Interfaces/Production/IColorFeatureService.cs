using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Interfaces.Production;

public interface IColorFeatureService
{
    ColorFeatureDto GetById(long id);
    IEnumerable<ColorFeatureListDto> GetAll();
    long Insert(ColorFeatureDto dto);
    void Update(ColorFeatureDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}

