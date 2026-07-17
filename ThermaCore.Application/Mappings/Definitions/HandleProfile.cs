using AutoMapper;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Domain.Entities.Definitions;
using ThermaCore.Domain.Helpers;

namespace ThermaCore.Application.Mappings.Definitions;

public class HandleProfile : Profile
{
    public HandleProfile()
    {
        CreateMap<Handle, HandleDto>()
            .ReverseMap()
            // Zırhlı Kural: AutoMapper Zehirlenmesi önlemi
            .ForMember(dest => dest.SpecialCode, opt => opt.Ignore());

        CreateMap<Handle, HandleListDto>()
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : string.Empty))
            .ForMember(dest => dest.HandleTypeName, opt => opt.MapFrom(src => src.HandleType.HasValue ? EnumFunctions.GetDescription(src.HandleType.Value) : string.Empty))
            .ForMember(dest => dest.MaterialTypeName, opt => opt.MapFrom(src => src.MaterialType.HasValue ? EnumFunctions.GetDescription(src.MaterialType.Value) : string.Empty));
    }
}
