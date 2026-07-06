using AutoMapper;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Mappings.Production;

public class BoyaProfile : Profile
{
    public BoyaProfile()
    {
        CreateMap<Boya, BoyaDto>().ReverseMap();
        
        CreateMap<Boya, BoyaListDto>()
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode.Name));
    }
}
