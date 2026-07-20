using AutoMapper;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Domain.Entities.Definitions;
using ThermaCore.Domain.Helpers;

namespace ThermaCore.Application.Mappings.Definitions;

public class FastenerProfile : Profile
{
    public FastenerProfile()
    {
        CreateMap<Fastener, FastenerListDto>()
            .ForMember(dest => dest.FastenerType, opt => opt.MapFrom(src => src.FastenerType.HasValue ? src.FastenerType.Value.GetDescription() : null))
            .ForMember(dest => dest.MaterialType, opt => opt.MapFrom(src => src.MaterialType.HasValue ? src.MaterialType.Value.GetDescription() : null))
            .ForMember(dest => dest.SpecialCode, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null))
            .ForMember(dest => dest.Standard, opt => opt.MapFrom(src => src.QualityStandard != null ? src.QualityStandard.Name : null));

        CreateMap<Fastener, FastenerDto>().ReverseMap()
            .ForMember(dest => dest.SpecialCode, opt => opt.Ignore())
            .ForMember(dest => dest.QualityStandard, opt => opt.Ignore());
    }
}
