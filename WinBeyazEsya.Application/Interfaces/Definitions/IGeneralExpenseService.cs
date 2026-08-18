using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Base;

namespace WinBeyazEsya.Application.Interfaces.Definitions
{
    public interface IGeneralExpenseService : IBaseService
    {
        GeneralExpenseDto GetById(long id);
        IEnumerable<GeneralExpenseListDto> GetAll();
        long Insert(GeneralExpenseDto dto);
        void Update(GeneralExpenseDto dto);
        void Delete(long id);
    }
}


