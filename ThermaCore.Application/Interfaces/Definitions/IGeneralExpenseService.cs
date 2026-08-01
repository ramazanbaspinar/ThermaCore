using System.Collections.Generic;
using ThermaCore.Application.DTOs.Definitions;

namespace ThermaCore.Application.Interfaces.Definitions
{
    public interface IGeneralExpenseService
    {
        GeneralExpenseDto GetById(long id);
        IEnumerable<GeneralExpenseListDto> GetAll();
        long Insert(GeneralExpenseDto dto);
        void Update(GeneralExpenseDto dto);
        void Delete(long id);
        bool IsCodeUnique(long id, string code);
    }
}
