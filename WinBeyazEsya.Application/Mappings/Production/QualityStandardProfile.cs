using AutoMapper;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Domain.Entities.Production;
using WinBeyazEsya.Domain.Helpers;

namespace WinBeyazEsya.Application.Mappings.Production;

public class QualityStandardProfile : Profile
{
    public QualityStandardProfile()
    {
        CreateMap<QualityStandard, QualityStandardDto>().ReverseMap();
        
        CreateMap<QualityStandard, QualityStandardListDto>()
            .ForMember(dest => dest.MaterialGroupName, opt => opt.MapFrom(src => src.MaterialGroup.GetDescription()));
    }
}

