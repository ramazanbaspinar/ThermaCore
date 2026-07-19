using AutoMapper;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Domain.Entities.Definitions;
using ThermaCore.Domain.Helpers;

namespace ThermaCore.Application.Mappings
{
    public class PlasticPartProfile : Profile
    {
        public PlasticPartProfile()
        {
            CreateMap<PlasticPart, PlasticPartDto>()
                .ReverseMap()
                .ForMember(d => d.SpecialCode, o => o.Ignore());

            CreateMap<PlasticPart, PlasticPartListDto>()
                .ForMember(dest => dest.SpecialCode, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : ""))
                .ForMember(dest => dest.PlasticPartCategory, opt => opt.MapFrom(src => src.PlasticPartCategory.HasValue ? EnumFunctions.GetDescription(src.PlasticPartCategory.Value) : ""))
                .ForMember(dest => dest.PlasticMaterialType, opt => opt.MapFrom(src => src.PlasticMaterialType.HasValue ? EnumFunctions.GetDescription(src.PlasticMaterialType.Value) : ""));
        }
    }
}
