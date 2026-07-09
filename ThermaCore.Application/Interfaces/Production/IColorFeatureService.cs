using System.Collections.Generic;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Interfaces.Production;

public interface IColorFeatureService
{
    ColorFeatureDto GetById(long id);
    IEnumerable<ColorFeatureListDto> GetAll();
    long Insert(ColorFeatureDto dto);
    void Update(ColorFeatureDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
