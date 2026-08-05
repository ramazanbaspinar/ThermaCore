using AutoMapper;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Application.Mappings.Production;

public class EmayeProfile : Profile
{
    public EmayeProfile()
    {
        CreateMap<Emaye, EmayeDto>().ReverseMap();
        
        CreateMap<Emaye, EmayeListDto>()
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null));
    }
}

