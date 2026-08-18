using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Services.Base;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Services.Definitions;

public class CityManager : BaseManager<CityDto, CityDto, City>, ICityService
{
    public CityManager(
        IMapper mapper,
        IRepository<City> repository,
        IUnitOfWork unitOfWork)
        : base(mapper, repository, unitOfWork, null)
    {
    }
}
