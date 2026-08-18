using Microsoft.EntityFrameworkCore;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Domain.Entities.Management;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Infrastructure.Persistence.Repositories;

public class CodeLogRepository : MasterRepository<CodeLog>, ICodeLogRepository
{
    public CodeLogRepository(WinBeyazEsyaMasterContext context) : base(context)
    {
    }

    public async Task<int> GetAndIncrementNextNumberAtomicAsync(ModuleType modul, string firmaKodu, string tarihKey, int baslangicSayisi, long? branchId)
    {
        var strategy = _context.Database.CreateExecutionStrategy();
        int result = default;

        await strategy.ExecuteAsync(async () =>
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
                    Id = WinBeyazEsya.Domain.Helpers.IdGenerator.GenerateId(),
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
            result = siradakiSayi;
        });

        return result;
    }
}

