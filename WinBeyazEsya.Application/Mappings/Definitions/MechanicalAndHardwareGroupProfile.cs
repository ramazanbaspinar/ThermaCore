using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Mappings.Definitions;

public class MechanicalAndHardwareGroupProfile : Profile
{
    public MechanicalAndHardwareGroupProfile()
    {
        CreateMap<MechanicalAndHardwareGroup, MechanicalAndHardwareGroupDto>()
            .ReverseMap()
            .ForMember(dest => dest.BaseUnit, opt => opt.Ignore())
            .ForMember(dest => dest.SpecialCode, opt => opt.Ignore());

        CreateMap<MechanicalAndHardwareGroup, MechanicalAndHardwareGroupListDto>()
            .ForMember(dest => dest.BaseUnitName, opt => opt.MapFrom(src => src.BaseUnit != null ? src.BaseUnit.Name : null));
    }
}
