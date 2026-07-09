using AutoMapper;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Mappings.Production;

public class CableProfile : Profile
{
    public CableProfile()
    {
        CreateMap<Cable, CableDto>().ReverseMap();
        CreateMap<Cable, CableListDto>()
            .ForMember(dest => dest.SpecialCode, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null));
    }
}
