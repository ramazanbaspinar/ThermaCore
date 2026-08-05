using AutoMapper;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Application.Mappings.Production;

public class RotarySwitchProfile : Profile
{
    public RotarySwitchProfile()
    {
        CreateMap<RotarySwitch, RotarySwitchDto>().ReverseMap();
        
        CreateMap<RotarySwitch, RotarySwitchListDto>()
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Name : null));
    }
}

