using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Infrastructure.Persistence.Repositories;

public class KodLogRepository : Repository<KodLog>, IKodLogRepository
{
    public KodLogRepository(ThermaCoreTenantContext context) : base(context)
    {
    }

    public async Task<int> GetAndIncrementNextNumberAtomicAsync(ModuleType modul, string firmaKodu, string tarihKey, int baslangicSayisi, long? branchId)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(global::System.Data.IsolationLevel.Serializable);

        var takip = await _context.KodLoglar
            .FirstOrDefaultAsync(x => x.Modul == modul &&
                                      x.FirmaKodu == firmaKodu &&
                                      x.TarihKey == tarihKey &&
                                      (branchId == null ? x.BranchId == null : x.BranchId == branchId));

        int siradakiSayi;
        if (takip == null)
        {
            siradakiSayi = baslangicSayisi;
            var yeniLog = new KodLog
            {
                Modul = modul,
                FirmaKodu = firmaKodu,
                TarihKey = tarihKey,
                BranchId = branchId,
                SonKodDegeri = siradakiSayi
            };
            _context.KodLoglar.Add(yeniLog);
            await _context.SaveChangesAsync();
        }
        else
        {
            siradakiSayi = takip.SonKodDegeri + 1;
            
            // ExecuteUpdate ile atomik artırım
            await _context.KodLoglar
                .Where(x => x.Id == takip.Id)
                .ExecuteUpdateAsync(s => s.SetProperty(p => p.SonKodDegeri, p => p.SonKodDegeri + 1));
        }

        await transaction.CommitAsync();
        return siradakiSayi;
    }
}
