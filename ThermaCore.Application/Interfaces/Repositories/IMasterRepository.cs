using System;
using System.Linq;
using System.Linq.Expressions;
using ThermaCore.Domain.Entities.Base.Interfaces;

namespace ThermaCore.Application.Interfaces.Repositories;

public interface IMasterRepository<TEntity> : IRepository<TEntity> where TEntity : class, IBaseEntity
{
}
