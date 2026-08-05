using AutoMapper;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Application.Mappings.Production;

public class KnobProfile : Profile
{
    public KnobProfile()
    {
        CreateMap<Knob, KnobDto>()
            .ForMember(dest => dest.SpecialCode, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null))
            .ReverseMap()
            .ForMember(dest => dest.SpecialCode, opt => opt.Ignore());

        CreateMap<Knob, KnobListDto>()
            .ForMember(dest => dest.SpecialCode, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null));
    }
}

