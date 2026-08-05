using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Mappings.Definitions;

public class GasketProfile : Profile
{
    public GasketProfile()
    {
        CreateMap<Gasket, GasketDto>()
            .ReverseMap()
            .ForMember(dest => dest.SpecialCode, opt => opt.Ignore());

        CreateMap<Gasket, GasketListDto>()
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null))
            .ForMember(dest => dest.MaterialTypeName, opt => opt.MapFrom(src => src.MaterialType != null ? WinBeyazEsya.Domain.Helpers.EnumFunctions.GetDescription(src.MaterialType.Value) : null));
    }
}

