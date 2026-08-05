using AutoMapper;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Application.Mappings.Production;

public class CableProfile : Profile
{
    public CableProfile()
    {
        CreateMap<Cable, CableDto>().ReverseMap();
        CreateMap<Cable, CableListDto>()
            .ForMember(dest => dest.SpecialCode, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null));
    }
}

