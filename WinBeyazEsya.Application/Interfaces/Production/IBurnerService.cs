using WinBeyazEsya.Application.DTOs.Production;
using System.Collections.Generic;

namespace WinBeyazEsya.Application.Interfaces.Production
{
    public interface IBurnerService
    {
        BurnerDto GetById(long id);
        IEnumerable<BurnerListDto> GetAll();
        long Insert(BurnerDto dto);
        void Update(BurnerDto dto);
        void Delete(long id);
        bool IsCodeUnique(long id, string code);
    }
}

