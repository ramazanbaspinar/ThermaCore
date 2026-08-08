using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Mappings.Definitions;

public class PlasticAndVisualPartsGroupProfile : Profile
{
    public PlasticAndVisualPartsGroupProfile()
    {
        CreateMap<PlasticAndVisualPartsGroup, PlasticAndVisualPartsGroupDto>()
            .ForMember(dest => dest.BaseUnitName, opt => opt.MapFrom(src => src.BaseUnit != null ? src.BaseUnit.Name : string.Empty))
            .ReverseMap()
            .ForMember(dest => dest.BaseUnit, opt => opt.Ignore())
            .ForMember(dest => dest.SpecialCode, opt => opt.Ignore());
            
        CreateMap<PlasticAndVisualPartsGroup, PlasticAndVisualPartsGroupListDto>()
            .ForMember(dest => dest.BaseUnitName, opt => opt.MapFrom(src => src.BaseUnit != null ? src.BaseUnit.Name : string.Empty));
    }
}
