using AutoMapper;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Mappings;

public class SurfaceTypeProfile : Profile
{
    public SurfaceTypeProfile()
    {
        CreateMap<SurfaceType, SurfaceTypeDto>().ReverseMap();
        CreateMap<SurfaceType, SurfaceTypeListDto>();
    }
}
