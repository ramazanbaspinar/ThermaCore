using System.Threading.Tasks;

namespace WinBeyazEsya.Application.Interfaces.Repositories;

public interface IUnitOfWork
{
    int SaveChanges();
    Task<int> SaveChangesAsync();
}

