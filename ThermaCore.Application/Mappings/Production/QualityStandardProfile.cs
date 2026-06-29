using AutoMapper;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Domain.Entities.Production;
using ThermaCore.Domain.Helpers;

namespace ThermaCore.Application.Mappings.Production;

public class QualityStandardProfile : Profile
{
    public QualityStandardProfile()
    {
        CreateMap<QualityStandard, QualityStandardDto>().ReverseMap();
        
        CreateMap<QualityStandard, QualityStandardListDto>()
            .ForMember(dest => dest.MaterialGroupName, opt => opt.MapFrom(src => src.MaterialGroup.GetDescription()));
    }
}
