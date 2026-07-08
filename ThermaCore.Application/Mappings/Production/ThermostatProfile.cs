using AutoMapper;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Mappings.Production;

public class ThermostatProfile : Profile
{
    public ThermostatProfile()
    {
        CreateMap<Thermostat, ThermostatDto>().ReverseMap();
        
        CreateMap<Thermostat, ThermostatListDto>()
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Name : null));
    }
}
