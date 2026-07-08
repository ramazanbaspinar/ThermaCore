using AutoMapper;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Mappings.Production;

public class OvenTimerProfile : Profile
{
    public OvenTimerProfile()
    {
        CreateMap<OvenTimer, OvenTimerDto>().ReverseMap();
        
        CreateMap<OvenTimer, OvenTimerListDto>()
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null));
    }
}
