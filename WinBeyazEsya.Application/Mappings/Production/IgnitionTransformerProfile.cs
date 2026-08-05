using AutoMapper;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Application.Mappings.Production;

public class IgnitionTransformerProfile : Profile
{
    public IgnitionTransformerProfile()
    {
        CreateMap<IgnitionTransformer, IgnitionTransformerDto>()
            .ReverseMap()
            .ForMember(dest => dest.SpecialCode, opt => opt.Ignore());
        
        CreateMap<IgnitionTransformer, IgnitionTransformerListDto>()
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Name : null));
    }
}

