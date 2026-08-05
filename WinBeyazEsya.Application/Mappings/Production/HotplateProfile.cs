using AutoMapper;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Domain.Entities.Production;
using WinBeyazEsya.Domain.Extensions;

namespace WinBeyazEsya.Application.Mappings.Production;

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

