using AutoMapper;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Application.Mappings.Production;

public class ColorFeatureProfile : Profile
{
    public ColorFeatureProfile()
    {
        CreateMap<ColorFeature, ColorFeatureDto>().ReverseMap();
        CreateMap<ColorFeature, ColorFeatureListDto>();
    }
}

