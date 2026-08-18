using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Mappings.Definitions;

public class CurrentAccountProfile : Profile
{
    public CurrentAccountProfile()
    {
        CreateMap<CurrentAccount, CurrentAccountDto>()
            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country != null ? src.Country.Title : null))
            .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City != null ? src.City.Title : null))
            .ForMember(dest => dest.TownName, opt => opt.MapFrom(src => src.Town != null ? src.Town.Title : null));

        CreateMap<CurrentAccountDto, CurrentAccount>();
    }
}
