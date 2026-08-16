using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Mappings.Definitions;

public class CountryProfile : Profile
{
    public CountryProfile()
    {
        CreateMap<CountryDto, Country>().ReverseMap();
    }
}
