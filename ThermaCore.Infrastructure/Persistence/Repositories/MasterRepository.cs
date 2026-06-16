using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Domain.Entities.Base;

namespace ThermaCore.Infrastructure.Persistence.Repositories;

public class MasterRepository<TEntity> : IMasterRepository<TEntity> where TEntity : Entity
{
    protected readonly ThermaCoreMasterContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public MasterRepository(ThermaCoreMasterContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public TEntity GetById(long id)
    {
        return _dbSet.Find(id)!;
    }

    public IQueryable<TEntity> GetAll()
    {
        return _dbSet;
    }

    public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }

    public void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void Remove(TEntity entity)
    {
        _dbSet.Remove(entity);
    }
}
