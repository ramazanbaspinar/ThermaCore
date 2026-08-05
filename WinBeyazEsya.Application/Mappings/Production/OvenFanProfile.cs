using AutoMapper;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Application.Mappings.Production;

public class OvenFanProfile : Profile
{
    public OvenFanProfile()
    {
        CreateMap<OvenFan, OvenFanDto>().ReverseMap();
        
        CreateMap<OvenFan, OvenFanListDto>()
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null));
    }
}

