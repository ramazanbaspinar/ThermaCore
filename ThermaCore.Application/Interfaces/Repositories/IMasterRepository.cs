using System;
using System.Linq;
using System.Linq.Expressions;
using ThermaCore.Domain.Entities.Base;

namespace ThermaCore.Application.Interfaces.Repositories;

public interface IMasterRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
}
