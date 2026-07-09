using AutoMapper;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Mappings.Production;

public class ColorFeatureProfile : Profile
{
    public ColorFeatureProfile()
    {
        CreateMap<ColorFeature, ColorFeatureDto>().ReverseMap();
        CreateMap<ColorFeature, ColorFeatureListDto>();
    }
}
