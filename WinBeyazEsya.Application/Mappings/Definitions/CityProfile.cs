using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Mappings.Definitions;

public class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<CityDto, City>().ReverseMap();
    }
}
