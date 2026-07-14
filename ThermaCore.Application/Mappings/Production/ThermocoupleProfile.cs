using AutoMapper;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Mappings.Production;

public class ThermocoupleProfile : Profile
{
    public ThermocoupleProfile()
    {
        CreateMap<Thermocouple, ThermocoupleDto>()
            .ForMember(dest => dest.SpecialCodeCode, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null))
            .ReverseMap()
            // CRITICAL RED LINE: Do not poison AutoMapper with Navigation Properties
            .ForMember(dest => dest.SpecialCode, opt => opt.Ignore());

        CreateMap<Thermocouple, ThermocoupleListDto>()
            .ForMember(dest => dest.SpecialCodeCode, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null));
    }
}
