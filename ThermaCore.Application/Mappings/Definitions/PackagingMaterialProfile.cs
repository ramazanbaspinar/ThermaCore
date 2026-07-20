using AutoMapper;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Domain.Entities.Definitions;
using ThermaCore.Domain.Helpers;

namespace ThermaCore.Application.Mappings.Definitions;

public class PackagingMaterialProfile : Profile
{
    public PackagingMaterialProfile()
    {
        CreateMap<PackagingMaterial, PackagingMaterialListDto>()
            .ForMember(dest => dest.PackagingType, opt => opt.MapFrom(src => src.PackagingType.HasValue ? src.PackagingType.Value.GetDescription() : null))
            .ForMember(dest => dest.PackagingMaterialType, opt => opt.MapFrom(src => src.PackagingMaterialType.HasValue ? src.PackagingMaterialType.Value.GetDescription() : null))
            .ForMember(dest => dest.SpecialCode, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null));

        CreateMap<PackagingMaterial, PackagingMaterialDto>().ReverseMap()
            .ForMember(dest => dest.SpecialCode, opt => opt.Ignore());
    }
}
