using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Base;

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
