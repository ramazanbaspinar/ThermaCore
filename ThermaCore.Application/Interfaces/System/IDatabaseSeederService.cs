using System.Threading.Tasks;

namespace ThermaCore.Application.Interfaces.System;

public interface IDatabaseSeederService
{
    Task SeedAsync(bool ilIlceYuklensin);
}
