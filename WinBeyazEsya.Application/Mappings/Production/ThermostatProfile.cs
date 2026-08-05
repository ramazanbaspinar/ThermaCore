using AutoMapper;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Application.Mappings.Production;

public class ThermostatProfile : Profile
{
    public ThermostatProfile()
    {
        CreateMap<Thermostat, ThermostatDto>().ReverseMap();
        
        CreateMap<Thermostat, ThermostatListDto>()
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Name : null));
    }
}

