using System.Threading.Tasks;
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
        return _context.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
