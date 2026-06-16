using System.Threading.Tasks;

namespace ThermaCore.Application.Interfaces.Repositories;

public interface IUnitOfWork
{
    int SaveChanges();
    Task<int> SaveChangesAsync();
}
