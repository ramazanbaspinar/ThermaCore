using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IGridService
{
    IEnumerable<GridListDto> GetAll();
    GridDto GetById(long id);
    long Insert(GridDto dto);
    void Update(GridDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}

