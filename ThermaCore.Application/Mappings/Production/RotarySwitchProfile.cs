using AutoMapper;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Mappings.Production;

public class RotarySwitchProfile : Profile
{
    public RotarySwitchProfile()
    {
        CreateMap<RotarySwitch, RotarySwitchDto>().ReverseMap();
        
        CreateMap<RotarySwitch, RotarySwitchListDto>()
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Name : null));
    }
}
