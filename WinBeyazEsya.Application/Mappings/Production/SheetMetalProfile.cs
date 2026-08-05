using AutoMapper;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Application.Mappings.Production;

public class SheetMetalProfile : Profile
{
    public SheetMetalProfile()
    {
        CreateMap<SheetMetal, SheetMetalDto>().ReverseMap();
        
        CreateMap<SheetMetal, SheetMetalListDto>()

            .ForMember(dest => dest.QualityStandardName, opt => opt.MapFrom(src => src.QualityStandard.Name))
            .ForMember(dest => dest.SurfaceTypeName, opt => opt.MapFrom(src => src.SurfaceType.Name))
            .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Unit.Name));
    }
}

