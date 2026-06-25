using ThermaCore.Application.Interfaces.Repositories.Definitions;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Infrastructure.Persistence.Repositories.Definitions;

public class ItemCategoryRepository : Repository<ItemCategory>, IItemCategoryRepository
{
    public ItemCategoryRepository(ThermaCoreTenantContext context) : base(context)
    {
    }
}
