using WinBeyazEsya.Application.Interfaces.Repositories.Definitions;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Infrastructure.Persistence.Repositories.Definitions;

public class UnitRepository : Repository<Unit>, IUnitRepository
{
    public UnitRepository(WinBeyazEsyaTenantContext context) : base(context)
    {
    }
}

