using AutoMapper;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Domain.Entities.Production;
using ThermaCore.Domain.Extensions;

namespace ThermaCore.Application.Mappings.Production;

public class HotplateProfile : Profile
{
    public HotplateProfile()
    {
        CreateMap<Hotplate, HotplateDto>().ReverseMap();
        
        CreateMap<Hotplate, HotplateListDto>()
            .ForMember(dest => dest.HotplateTypeName, opt => opt.MapFrom(src => src.HotplateType.HasValue ? src.HotplateType.Value.ToName() : null))
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Name : null));
    }
}
