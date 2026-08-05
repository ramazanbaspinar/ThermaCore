using AutoMapper;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Application.Mappings.Production;

public class GlassTypeProfile : Profile
{
    public GlassTypeProfile()
    {
        CreateMap<GlassType, GlassTypeDto>().ReverseMap();
        CreateMap<GlassType, GlassTypeListDto>();
    }
}

