using WinBeyazEsya.Application.Interfaces.Base;
using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

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


