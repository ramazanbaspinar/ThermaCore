using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Mappings.Definitions;

public class ElectricalElectronicGroupProfile : Profile
{
    public ElectricalElectronicGroupProfile()
    {
        CreateMap<ElectricalElectronicGroup, ElectricalElectronicGroupDto>()
            .ForMember(dest => dest.BaseUnitName, opt => opt.MapFrom(src => src.BaseUnit != null ? src.BaseUnit.Name : string.Empty))
            .ReverseMap()
            .ForMember(dest => dest.BaseUnit, opt => opt.Ignore())
            .ForMember(dest => dest.SpecialCode, opt => opt.Ignore());

        CreateMap<ElectricalElectronicGroup, ElectricalElectronicGroupListDto>()
            .ForMember(dest => dest.BaseUnitName, opt => opt.MapFrom(src => src.BaseUnit != null ? src.BaseUnit.Name : string.Empty));
    }
}
