using AutoMapper;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Mappings.Production;

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
