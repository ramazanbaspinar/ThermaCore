using System.Threading.Tasks;

namespace ThermaCore.Application.Interfaces.Repositories;

public interface IMasterUnitOfWork
{
    int SaveChanges();
    Task<int> SaveChangesAsync();
}
