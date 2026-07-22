using AutoMapper;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Application.Mappings.Definitions;

public class UnitConversionProfile : Profile
{
    public UnitConversionProfile()
    {
        CreateMap<UnitConversion, UnitConversionDto>().ReverseMap();

        // Optional mapping to resolve UnitName if a repository provides it by Include
        CreateMap<UnitConversion, UnitConversionListDto>()
            .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => "")); // Will be populated in service or projection if needed. Assuming Unit nav property is not defined or we don't have it.
            
        // Wait, does UnitConversion have a Unit navigation property? I didn't add one in Domain.
        // Let me refine it:
    }
}
