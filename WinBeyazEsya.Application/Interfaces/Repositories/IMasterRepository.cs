using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Application.Interfaces.Repositories;

public interface IMasterRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
}

