using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WinBeyazEsya.Application.Interfaces.Repositories;

namespace WinBeyazEsya.Infrastructure.Persistence.Repositories;

public class MasterUnitOfWork : IMasterUnitOfWork
{
    private readonly WinBeyazEsyaMasterContext _context;

    public MasterUnitOfWork(WinBeyazEsyaMasterContext context)
    {
        _context = context;
    }

    public int SaveChanges()
    {
        try
        {
            return _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            Serilog.Log.Error(ex, "MasterUnitOfWork.SaveChanges: Concurrency hatası oluştu.");
            throw new global::System.Exception("Bu kayıt siz işlemi başlatmadan önce başka bir kullanıcı (veya işlem) tarafından değiştirilmiş veya silinmiş. Lütfen kaydı yenileyerek işleminizi tekrar ediniz.");
        }
        catch (DbUpdateException ex)
        {
            HandleDbUpdateException(ex);
            throw;
        }
    }

    public async Task<int> SaveChangesAsync()
    {
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            Serilog.Log.Error(ex, "MasterUnitOfWork.SaveChangesAsync: Concurrency hatası oluştu.");
            throw new global::System.Exception("Bu kayıt siz işlemi başlatmadan önce başka bir kullanıcı (veya işlem) tarafından değiştirilmiş veya silinmiş. Lütfen kaydı yenileyerek işleminizi tekrar ediniz.");
        }
        catch (DbUpdateException ex)
        {
            HandleDbUpdateException(ex);
            throw;
        }
    }

    private void HandleDbUpdateException(DbUpdateException ex)
    {
        Serilog.Log.Error(ex, "Master veritabanı kayıt işlemi (DbUpdateException) sırasında hata oluştu.");
        _context.ChangeTracker.Clear();

        var sqlEx = ex.InnerException as Microsoft.Data.SqlClient.SqlException ?? 
                    ex.InnerException?.InnerException as Microsoft.Data.SqlClient.SqlException;

        if (sqlEx != null)
        {
            switch (sqlEx.Number)
            {
                case 208:
                    throw new global::System.Exception("İşlem Başarısız: İşlem yapmak istediğiniz tablo veritabanında bulunamadı.");
                case 547:
                    throw new global::System.Exception("İşlem Başarısız: Seçilen kaydın işlem görmüş hareketleri (bağlı kayıtları) var. Bu kayıt silinemez.");
                case 2601:
                case 2627:
                    throw new global::System.Exception("İşlem Başarısız: Girmiş olduğunuz Kod veya benzersiz (Unique) alan daha önceden kullanılmıştır. Lütfen farklı bir değer giriniz.");
                case 4060:
                    throw new global::System.Exception("İşlem Başarısız: İşlem yapmak istediğiniz veritabanı sunucuda bulunamadı.");
                case 18456:
                    throw new global::System.Exception("İşlem Başarısız: Veritabanına bağlanmak istediğiniz kullanıcı adı veya şifre hatalıdır.");
                default:
                    throw new global::System.Exception("İşlem Başarısız: " + sqlEx.Message);
            }
        }
        throw new global::System.Exception("İşlem Başarısız: " + (ex.InnerException?.Message ?? ex.Message));
    }
}

