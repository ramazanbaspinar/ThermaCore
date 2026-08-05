using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Domain.Entities.Definitions;
using WinBeyazEsya.Domain.Helpers;

namespace WinBeyazEsya.Application.Mappings.Definitions;

public class FittingProfile : Profile
{
    public FittingProfile()
    {
        CreateMap<Fitting, FittingDto>()
            .ReverseMap()
            // Zırhlı Kural: AutoMapper Zehirlenmesi önlemi
            .ForMember(dest => dest.SpecialCode, opt => opt.Ignore());

        CreateMap<Fitting, FittingListDto>()
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : string.Empty))
            .ForMember(dest => dest.FittingTypeName, opt => opt.MapFrom(src => src.FittingType.HasValue ? EnumFunctions.GetDescription(src.FittingType.Value) : string.Empty))
            .ForMember(dest => dest.MaterialTypeName, opt => opt.MapFrom(src => src.MaterialType.HasValue ? EnumFunctions.GetDescription(src.MaterialType.Value) : string.Empty));
    }
}

