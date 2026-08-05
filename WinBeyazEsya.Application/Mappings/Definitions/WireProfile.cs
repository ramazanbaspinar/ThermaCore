using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Domain.Entities.Definitions;
using WinBeyazEsya.Domain.Helpers;

namespace WinBeyazEsya.Application.Mappings.Definitions;

public class WireProfile : Profile
{
    public WireProfile()
    {
        CreateMap<Wire, WireDto>()
            .ReverseMap()
            .ForMember(dest => dest.SpecialCode, opt => opt.Ignore());

        CreateMap<Wire, WireListDto>()
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : string.Empty))
            .ForMember(dest => dest.WireTypeName, opt => opt.MapFrom(src => src.WireType.HasValue ? EnumFunctions.GetDescription(src.WireType.Value) : string.Empty));
    }
}

