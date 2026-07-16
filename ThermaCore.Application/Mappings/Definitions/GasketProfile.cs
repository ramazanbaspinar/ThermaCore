using AutoMapper;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Application.Mappings.Definitions;

public class GasketProfile : Profile
{
    public GasketProfile()
    {
        CreateMap<Gasket, GasketDto>()
            .ReverseMap()
            .ForMember(dest => dest.SpecialCode, opt => opt.Ignore());

        CreateMap<Gasket, GasketListDto>()
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null))
            .ForMember(dest => dest.MaterialTypeName, opt => opt.MapFrom(src => src.MaterialType != null ? ThermaCore.Domain.Helpers.EnumFunctions.GetDescription(src.MaterialType.Value) : null));
    }
}
