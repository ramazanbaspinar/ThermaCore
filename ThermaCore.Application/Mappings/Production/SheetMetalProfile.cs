using AutoMapper;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Mappings.Production;

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
