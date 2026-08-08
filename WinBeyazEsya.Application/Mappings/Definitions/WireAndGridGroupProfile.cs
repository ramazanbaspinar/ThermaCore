using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Mappings.Definitions;

public class WireAndGridGroupProfile : Profile
{
    public WireAndGridGroupProfile()
    {
        CreateMap<WireAndGridGroup, WireAndGridGroupDto>()
            .ReverseMap()
            .ForMember(dest => dest.BaseUnit, opt => opt.Ignore())
            .ForMember(dest => dest.SpecialCode, opt => opt.Ignore());

        CreateMap<WireAndGridGroup, WireAndGridGroupListDto>()
            .ForMember(dest => dest.BaseUnitName, opt => opt.MapFrom(src => src.BaseUnit != null ? src.BaseUnit.Name : string.Empty));
    }
}
