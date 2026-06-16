using System.Threading.Tasks;
using ThermaCore.Application.Interfaces.Repositories;

namespace ThermaCore.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ThermaCoreContext _context;

    public UnitOfWork(ThermaCoreContext context)
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
