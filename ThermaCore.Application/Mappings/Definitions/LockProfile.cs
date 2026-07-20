using AutoMapper;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Domain.Entities.Definitions;
using ThermaCore.Domain.Helpers;

namespace ThermaCore.Application.Mappings.Definitions;

public class LockProfile : Profile
{
    public LockProfile()
    {
        CreateMap<Lock, LockListDto>()
            .ForMember(dest => dest.LockType, opt => opt.MapFrom(src => src.LockType.HasValue ? src.LockType.Value.GetDescription() : null))
            .ForMember(dest => dest.MaterialType, opt => opt.MapFrom(src => src.MaterialType.HasValue ? src.MaterialType.Value.GetDescription() : null))
            .ForMember(dest => dest.SpecialCodeCode, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : null));

        CreateMap<Lock, LockDto>().ReverseMap()
            .ForMember(dest => dest.SpecialCode, opt => opt.Ignore());
    }
}
