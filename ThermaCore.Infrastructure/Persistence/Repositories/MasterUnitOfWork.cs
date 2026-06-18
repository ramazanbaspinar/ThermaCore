using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThermaCore.Application.Interfaces.Repositories;

namespace ThermaCore.Infrastructure.Persistence.Repositories;

public class MasterUnitOfWork : IMasterUnitOfWork
{
    private readonly ThermaCoreMasterContext _context;

    public MasterUnitOfWork(ThermaCoreMasterContext context)
    {
        _context = context;
    }

    public int SaveChanges()
    {
        try
        {
            return _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
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
        catch (DbUpdateConcurrencyException)
        {
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
        var sqlEx = ex.InnerException as Microsoft.Data.SqlClient.SqlException ?? 
                    ex.InnerException?.InnerException as Microsoft.Data.SqlClient.SqlException;

        if (sqlEx != null)
        {
            switch (sqlEx.Number)
            {
                case 208:
                    throw new global::System.Exception("İşlem yapmak istediğiniz tablo veritabanında bulunamadı.");
                case 547:
                    throw new global::System.Exception("Seçilen kaydın işlem görmüş hareketleri (bağlı kayıtları) var. Bu kayıt silinemez.");
                case 2601:
                case 2627:
                    throw new global::System.Exception("Girmiş olduğunuz Kod veya benzersiz (Unique) alan daha önceden kullanılmıştır. Lütfen farklı bir değer giriniz.");
                case 4060:
                    throw new global::System.Exception("İşlem yapmak istediğiniz veritabanı sunucuda bulunamadı.");
                case 18456:
                    throw new global::System.Exception("Veritabanına bağlanmak istediğiniz kullanıcı adı veya şifre hatalıdır.");
                default:
                    throw new global::System.Exception(sqlEx.Message);
            }
        }
        throw new global::System.Exception(ex.InnerException?.Message ?? ex.Message);
    }
}
