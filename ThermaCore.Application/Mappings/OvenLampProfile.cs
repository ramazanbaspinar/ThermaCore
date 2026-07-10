using AutoMapper;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Domain.Entities.Production;
using ThermaCore.Domain.Extensions;

namespace ThermaCore.Application.Mappings;

public class OvenLampProfile : Profile
{
    public OvenLampProfile()
    {
        CreateMap<OvenLamp, OvenLampDto>().ReverseMap();
        
        CreateMap<OvenLamp, OvenLampListDto>()
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Name : string.Empty))
            .ForMember(dest => dest.LampTypeName, opt => opt.MapFrom(src => src.LampType.HasValue ? src.LampType.Value.ToName() : string.Empty));
    }
}
