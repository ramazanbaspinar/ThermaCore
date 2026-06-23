using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Infrastructure.Persistence.Repositories;

public class CodeLogRepository : MasterRepository<CodeLog>, ICodeLogRepository
{
    public CodeLogRepository(ThermaCoreMasterContext context) : base(context)
    {
    }

    public async Task<int> GetAndIncrementNextNumberAtomicAsync(ModuleType modul, string firmaKodu, string tarihKey, int baslangicSayisi, long? branchId)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(global::System.Data.IsolationLevel.Serializable);

        var takip = await _context.CodeLogs
            .FirstOrDefaultAsync(x => x.Module == modul &&
                                      x.CompanyCode == firmaKodu &&
                                      x.DateKey == tarihKey &&
                                      (branchId == null ? x.BranchId == null : x.BranchId == branchId));

        int siradakiSayi;
        if (takip == null)
        {
            siradakiSayi = baslangicSayisi;
            var yeniLog = new CodeLog
            {
                Id = ThermaCore.Domain.Helpers.IdGenerator.GenerateId(),
                Module = modul,
                CompanyCode = firmaKodu,
                DateKey = tarihKey,
                BranchId = branchId,
                LastCodeValue = siradakiSayi
            };
            _context.CodeLogs.Add(yeniLog);
            await _context.SaveChangesAsync();
        }
        else
        {
            siradakiSayi = takip.LastCodeValue + 1;
            takip.LastCodeValue = siradakiSayi;
            await _context.SaveChangesAsync();
        }

        await transaction.CommitAsync();
        return siradakiSayi;
    }
}
