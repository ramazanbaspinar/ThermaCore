using System.Collections.Generic;
using ThermaCore.Application.DTOs.Definitions;

namespace ThermaCore.Application.Interfaces.Definitions;

public interface IGridService
{
    IEnumerable<GridListDto> GetAll();
    GridDto GetById(long id);
    long Insert(GridDto dto);
    void Update(GridDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
