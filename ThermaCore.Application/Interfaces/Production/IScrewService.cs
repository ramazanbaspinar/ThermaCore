using System.Collections.Generic;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Interfaces.Production;

public interface IScrewService
{
    ScrewDto GetById(long id);
    IEnumerable<ScrewListDto> GetAll();
    long Insert(ScrewDto dto);
    void Update(ScrewDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
