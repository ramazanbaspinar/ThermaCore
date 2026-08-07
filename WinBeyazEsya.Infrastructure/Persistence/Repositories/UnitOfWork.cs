using System.Threading.Tasks;
using WinBeyazEsya.Application.Interfaces.Repositories;

namespace WinBeyazEsya.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly WinBeyazEsyaTenantContext _context;

    public UnitOfWork(WinBeyazEsyaTenantContext context)
    {
        _context = context;
    }

    public int SaveChanges()
    {
        try
        {
            return _context.SaveChanges(); // Interceptorlarımız tetiklenecek
        }
        catch (global::System.Exception ex)
        {
            Serilog.Log.Error(ex, "Veritabanına kayıt işlemi sırasında (UnitOfWork) hata oluştu.");
            throw;
        }
    }

    public async Task<int> SaveChangesAsync()
    {
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (global::System.Exception ex)
        {
            Serilog.Log.Error(ex, "Veritabanına asenkron kayıt işlemi sırasında (UnitOfWork) hata oluştu.");
            throw;
        }
    }
}

