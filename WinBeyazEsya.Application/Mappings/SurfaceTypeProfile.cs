using AutoMapper;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Application.Mappings;

public class SurfaceTypeProfile : Profile
{
    public SurfaceTypeProfile()
    {
        CreateMap<SurfaceType, SurfaceTypeDto>().ReverseMap();
        CreateMap<SurfaceType, SurfaceTypeListDto>();
    }
}

