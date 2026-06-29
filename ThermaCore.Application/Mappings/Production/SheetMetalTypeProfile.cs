using AutoMapper;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Mappings.Production;

public class SheetMetalTypeProfile : Profile
{
    public SheetMetalTypeProfile()
    {
        CreateMap<SheetMetalType, SheetMetalTypeDto>().ReverseMap();
        CreateMap<SheetMetalType, SheetMetalTypeListDto>().ReverseMap();
    }
}
