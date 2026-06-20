using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Domain.Entities.Base;

namespace ThermaCore.Infrastructure.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    protected readonly ThermaCoreTenantContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public Repository(ThermaCoreTenantContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public TEntity GetById(long id)
    {
        var entity = _dbSet.Find(id);
        if (entity != null)
        {
            // WinForms'ta DbContext uzun süre yaşayabildiği için,
            // bellekteki eski state/rowversion yerine DB'den en güncel halini zorla çeker.
            _context.Entry(entity).Reload();
        }
        return entity!;
    }

    public IQueryable<TEntity> GetAll()
    {
        return _dbSet.AsNoTracking();
    }

    public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.AsNoTracking().Where(predicate);
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
        var local = _dbSet.Local.FirstOrDefault(e => e.Id == entity.Id);
        if (local != null)
        {
            // Zaten takip ediliyorsa (Önceki save vs. sebebiyle), localdekini sil olarak işaretle
            _dbSet.Remove(local);
        }
        else
        {
            // Takip edilmiyorsa (AsNoTracking ile gelmişse) normal Remove yap
            _dbSet.Remove(entity);
        }
    }
}
