using AutoMapper;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Mappings.Production;

public class SparkPlugProfile : Profile
{
    public SparkPlugProfile()
    {
        CreateMap<SparkPlug, SparkPlugDto>()
            .ForMember(dest => dest.SpecialCodeCode, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null))
            .ReverseMap()
            // RED LINE: Prevent AutoMapper from poisoning Navigation Properties during mapping
            .ForMember(dest => dest.SpecialCode, opt => opt.Ignore());

        CreateMap<SparkPlug, SparkPlugListDto>()
            .ForMember(dest => dest.SpecialCodeCode, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null));
    }
}
