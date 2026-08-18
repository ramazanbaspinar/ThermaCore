using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Services.Definitions;

public class CountryManager : BaseManager<CountryDto, CountryDto, Country>, ICountryService
{
    public CountryManager(
        IMapper mapper,
        IRepository<Country> repository,
        IUnitOfWork unitOfWork)
        : base(mapper, repository, unitOfWork, null)
    {
    }
}
