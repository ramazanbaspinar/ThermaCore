namespace WinBeyazEsya.Application.Interfaces.Repositories;

public interface IMasterUnitOfWork
{
    int SaveChanges();
    Task<int> SaveChangesAsync();
}

