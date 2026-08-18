using WinBeyazEsya.Domain.Entities.Management;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.Interfaces.Repositories;

public interface ICodeLogRepository : IMasterRepository<CodeLog>
{
    Task<int> GetAndIncrementNextNumberAtomicAsync(ModuleType modul, string firmaKodu, string tarihKey, int baslangicSayisi, long? branchId);
}

