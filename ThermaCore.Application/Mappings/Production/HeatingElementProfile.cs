using AutoMapper;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Mappings.Production;

public class HeatingElementProfile : Profile
{
    public HeatingElementProfile()
    {
        CreateMap<HeatingElement, HeatingElementDto>().ReverseMap();
        CreateMap<HeatingElement, HeatingElementListDto>();
    }
}
