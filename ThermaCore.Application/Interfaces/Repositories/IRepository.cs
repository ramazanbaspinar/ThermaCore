using System;
using System.Linq;
using System.Linq.Expressions;
using ThermaCore.Domain.Entities.Base.Interfaces;

namespace ThermaCore.Application.Interfaces.Repositories;

public interface IRepository<TEntity> where TEntity : class, IBaseEntity
{
    TEntity GetById(long id);
    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
}
