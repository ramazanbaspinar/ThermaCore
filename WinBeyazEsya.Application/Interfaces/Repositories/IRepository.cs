using System;
using System.Linq;
using System.Linq.Expressions;
using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Application.Interfaces.Repositories;

public interface IRepository<TEntity> where TEntity : Entity
{
    TEntity GetById(long id);
    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);
    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    bool IsInUse(TEntity entity);
}

