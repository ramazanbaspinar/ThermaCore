using AutoMapper;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Mappings.Production;

public class ScrewProfile : Profile
{
    public ScrewProfile()
    {
        CreateMap<Screw, ScrewDto>().ReverseMap();
        
        CreateMap<Screw, ScrewListDto>()
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null));
    }
}
