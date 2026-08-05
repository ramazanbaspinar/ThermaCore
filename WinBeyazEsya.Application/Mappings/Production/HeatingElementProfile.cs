using AutoMapper;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Application.Mappings.Production;

public class HeatingElementProfile : Profile
{
    public HeatingElementProfile()
    {
        CreateMap<HeatingElement, HeatingElementDto>().ReverseMap();
        CreateMap<HeatingElement, HeatingElementListDto>();
    }
}

