using AutoMapper;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Mappings.Production;

public class EmayeProfile : Profile
{
    public EmayeProfile()
    {
        CreateMap<Emaye, EmayeDto>().ReverseMap();
        
        CreateMap<Emaye, EmayeListDto>()
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null));
    }
}
