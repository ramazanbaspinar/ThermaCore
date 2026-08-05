using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Infrastructure.Persistence.Repositories;

public class MasterRepository<TEntity> : IMasterRepository<TEntity> where TEntity : Entity
{
    protected readonly WinBeyazEsyaMasterContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public MasterRepository(WinBeyazEsyaMasterContext context)
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
        var local = _dbSet.Local.FirstOrDefault(e => e.Id == entity.Id);
        if (local != null)
        {
            _context.Entry(local).CurrentValues.SetValues(entity);
        }
        else
        {
            _dbSet.Update(entity);
        }
    }

    public void Remove(TEntity entity)
    {
        var local = _dbSet.Local.FirstOrDefault(e => e.Id == entity.Id);
        if (local != null)
        {
            _dbSet.Remove(local);
        }
        else
        {
            _dbSet.Remove(entity);
        }
    }

    public bool IsInUse(TEntity entity)
    {
        var entityType = _context.Model.FindEntityType(typeof(TEntity));
        if (entityType == null) return false;

        foreach (var fk in entityType.GetReferencingForeignKeys())
        {
            if (fk.DeleteBehavior == DeleteBehavior.Cascade) continue;

            var dependentType = fk.DeclaringEntityType.ClrType;
            var fkProperty = fk.Properties[0].PropertyInfo; 

            if (fkProperty == null) continue;

            var setMethod = _context.GetType().GetMethods()
                .FirstOrDefault(m => m.Name == "Set" && m.GetParameters().Length == 0 && m.IsGenericMethod)
                ?.MakeGenericMethod(dependentType);

            if (setMethod == null) continue;

            var dbSet = setMethod.Invoke(_context, null) as IQueryable;
            if (dbSet == null) continue;

            var param = Expression.Parameter(dependentType, "x");
            var propAccess = Expression.Property(param, fkProperty);
            
            Expression idValue = Expression.Constant(entity.Id, typeof(long));
            Expression left = propAccess;
            Expression right = idValue;

            if (left.Type != right.Type)
            {
                if (left.Type.IsGenericType && left.Type.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    right = Expression.Convert(right, left.Type);
                }
                else if (right.Type.IsGenericType && right.Type.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    left = Expression.Convert(left, right.Type);
                }
            }
            
            var equalExp = Expression.Equal(left, right);
            var lambda = Expression.Lambda(equalExp, param);

            var anyMethod = typeof(Queryable).GetMethods()
                .First(m => m.Name == "Any" && m.GetParameters().Length == 2)
                .MakeGenericMethod(dependentType);
            
            bool isUsed = (bool)anyMethod.Invoke(null, new object[] { dbSet, lambda });
            if (isUsed) return true;
        }

        return false;
    }
}

