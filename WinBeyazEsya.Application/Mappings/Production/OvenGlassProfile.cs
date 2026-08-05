using AutoMapper;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Application.Mappings.Production;

public class OvenGlassProfile : Profile
{
    public OvenGlassProfile()
    {
        CreateMap<OvenGlass, OvenGlassDto>()
            .ForMember(dest => dest.SpecialCode, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null))
            .ForMember(dest => dest.GlassTypeName, opt => opt.MapFrom(src => src.GlassType != null ? src.GlassType.Name : null))
            .ForMember(dest => dest.ColorFeatureName, opt => opt.MapFrom(src => src.ColorFeature != null ? src.ColorFeature.Name : null));

        CreateMap<OvenGlassDto, OvenGlass>()
            .ForMember(dest => dest.SpecialCode, opt => opt.Ignore())
            .ForMember(dest => dest.GlassType, opt => opt.Ignore())
            .ForMember(dest => dest.ColorFeature, opt => opt.Ignore());

        CreateMap<OvenGlass, OvenGlassListDto>()
            .ForMember(dest => dest.SpecialCode, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null))
            .ForMember(dest => dest.GlassTypeName, opt => opt.MapFrom(src => src.GlassType != null ? src.GlassType.Name : null))
            .ForMember(dest => dest.ColorFeatureName, opt => opt.MapFrom(src => src.ColorFeature != null ? src.ColorFeature.Name : null));
    }
}

