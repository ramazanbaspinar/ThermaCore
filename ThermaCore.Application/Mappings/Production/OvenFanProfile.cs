using AutoMapper;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Mappings.Production;

public class OvenFanProfile : Profile
{
    public OvenFanProfile()
    {
        CreateMap<OvenFan, OvenFanDto>().ReverseMap();
        
        CreateMap<OvenFan, OvenFanListDto>()
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null));
    }
}
