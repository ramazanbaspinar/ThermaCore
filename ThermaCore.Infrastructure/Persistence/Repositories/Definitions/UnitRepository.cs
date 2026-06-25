using ThermaCore.Application.Interfaces.Repositories.Definitions;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Infrastructure.Persistence.Repositories.Definitions;

public class UnitRepository : Repository<Unit>, IUnitRepository
{
    public UnitRepository(ThermaCoreTenantContext context) : base(context)
    {
    }
}
