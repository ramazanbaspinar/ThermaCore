using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Domain.Entities.Definitions;
using WinBeyazEsya.Domain.Helpers;

namespace WinBeyazEsya.Application.Mappings.Definitions;

public class ManualProfile : Profile
{
    public ManualProfile()
    {
        CreateMap<Manual, ManualListDto>()
            .ForMember(dest => dest.ManualType, opt => opt.MapFrom(src => src.ManualType.HasValue ? src.ManualType.Value.GetDescription() : null))
            .ForMember(dest => dest.PaperType, opt => opt.MapFrom(src => src.PaperType.HasValue ? src.PaperType.Value.GetDescription() : null))
            .ForMember(dest => dest.LanguageCode, opt => opt.MapFrom(src => src.LanguageCode.HasValue ? src.LanguageCode.Value.GetDescription() : null))
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null));

        CreateMap<Manual, ManualDto>().ReverseMap()
            .ForMember(dest => dest.SpecialCode, opt => opt.Ignore());
    }
}

