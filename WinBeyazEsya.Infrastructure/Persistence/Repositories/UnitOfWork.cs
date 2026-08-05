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
        return _context.SaveChanges(); // Interceptorlarımız tetiklenecek
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}

