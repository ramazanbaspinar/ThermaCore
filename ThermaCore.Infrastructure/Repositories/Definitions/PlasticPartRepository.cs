using ThermaCore.Application.Interfaces.Repositories.Definitions;
using ThermaCore.Domain.Entities.Definitions;
using ThermaCore.Infrastructure.Persistence;
using ThermaCore.Infrastructure.Persistence.Repositories;

namespace ThermaCore.Infrastructure.Repositories.Definitions
{
    public class PlasticPartRepository : Repository<PlasticPart>, IPlasticPartRepository
    {
        public PlasticPartRepository(ThermaCoreTenantContext context) : base(context)
        {
        }
    }
}
