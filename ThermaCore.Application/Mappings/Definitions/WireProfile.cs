using AutoMapper;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Domain.Entities.Definitions;
using ThermaCore.Domain.Helpers;

namespace ThermaCore.Application.Mappings.Definitions;

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
