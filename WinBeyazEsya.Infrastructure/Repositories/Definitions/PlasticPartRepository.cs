using WinBeyazEsya.Application.Interfaces.Repositories.Definitions;
using WinBeyazEsya.Domain.Entities.Definitions;
using WinBeyazEsya.Infrastructure.Persistence;
using WinBeyazEsya.Infrastructure.Persistence.Repositories;

namespace WinBeyazEsya.Infrastructure.Repositories.Definitions
{
    public class PlasticPartRepository : Repository<PlasticPart>, IPlasticPartRepository
    {
        public PlasticPartRepository(WinBeyazEsyaTenantContext context) : base(context)
        {
        }
    }
}

