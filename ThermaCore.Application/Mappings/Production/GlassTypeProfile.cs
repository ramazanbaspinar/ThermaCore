using AutoMapper;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Mappings.Production;

public class GlassTypeProfile : Profile
{
    public GlassTypeProfile()
    {
        CreateMap<GlassType, GlassTypeDto>().ReverseMap();
        CreateMap<GlassType, GlassTypeListDto>();
    }
}
