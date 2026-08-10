using WinBeyazEsya.Application.Interfaces.Base;
using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IFinishedGoodService : IBaseService
{
    FinishedGoodDto GetById(long id);
    IEnumerable<FinishedGoodListDto> GetAll();
    long Insert(FinishedGoodDto dto);
    void Update(FinishedGoodDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
