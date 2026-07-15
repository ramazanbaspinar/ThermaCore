using System.Collections.Generic;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Interfaces.Production;

public interface IGasPipeService
{
    GasPipeDto GetById(long id);
    IEnumerable<GasPipeListDto> GetAll();
    long Insert(GasPipeDto dto);
    void Update(GasPipeDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
