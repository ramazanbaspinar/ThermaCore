using System.Collections.Generic;
using System.Threading.Tasks;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Interfaces.Production;

public interface IHotplateService
{
    HotplateDto GetById(long id);
    IEnumerable<HotplateListDto> GetAllList();
    IEnumerable<HotplateListDto> GetActiveList();
    long Insert(HotplateDto dto);
    void Update(HotplateDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}

