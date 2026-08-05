using AutoMapper;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Application.Mappings.Production;

public class ScrewProfile : Profile
{
    public ScrewProfile()
    {
        CreateMap<Screw, ScrewDto>().ReverseMap();
        
        CreateMap<Screw, ScrewListDto>()
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null));
    }
}

