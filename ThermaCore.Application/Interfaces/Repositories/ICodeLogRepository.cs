using System.Threading.Tasks;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.Interfaces.Repositories;

public interface ICodeLogRepository : IMasterRepository<CodeLog>
{
    Task<int> GetAndIncrementNextNumberAtomicAsync(ModuleType modul, string firmaKodu, string tarihKey, int baslangicSayisi, long? branchId);
}
