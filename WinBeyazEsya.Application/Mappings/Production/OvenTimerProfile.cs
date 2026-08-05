using AutoMapper;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Application.Mappings.Production;

public class OvenTimerProfile : Profile
{
    public OvenTimerProfile()
    {
        CreateMap<OvenTimer, OvenTimerDto>().ReverseMap();
        
        CreateMap<OvenTimer, OvenTimerListDto>()
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null));
    }
}

