using System.Threading.Tasks;

namespace WinBeyazEsya.Application.Interfaces.System;

public interface IDatabaseSeederService
{
    Task SeedAsync(bool ilIlceYuklensin);
}

