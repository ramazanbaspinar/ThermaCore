using AutoMapper;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Domain.Entities.Definitions;
using ThermaCore.Domain.Helpers;

namespace ThermaCore.Application.Mappings.Definitions;

public class InsulationProfile : Profile
{
    public InsulationProfile()
    {
        CreateMap<Insulation, InsulationDto>()
            .ReverseMap()
            .ForMember(dest => dest.SpecialCode, opt => opt.Ignore());

        CreateMap<Insulation, InsulationListDto>()
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null))
            .ForMember(dest => dest.InsulationTypeName, opt => opt.MapFrom(src => src.InsulationType != null ? EnumFunctions.GetDescription(src.InsulationType.Value) : null));
    }
}
