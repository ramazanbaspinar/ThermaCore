using AutoMapper;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Mappings.Production;

public class GasValveProfile : Profile
{
    public GasValveProfile()
    {
        CreateMap<GasValve, GasValveDto>()
            .ForMember(dest => dest.SpecialCodeCode, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null))
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Name : null));

        CreateMap<GasValveDto, GasValve>()
            .ForMember(dest => dest.SpecialCode, opt => opt.Ignore());

        CreateMap<GasValve, GasValveListDto>()
            .ForMember(dest => dest.SpecialCodeCode, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null))
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Name : null));
    }
}
