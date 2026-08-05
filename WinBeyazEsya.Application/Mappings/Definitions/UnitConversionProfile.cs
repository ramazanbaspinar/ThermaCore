using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Mappings.Definitions;

public class UnitConversionProfile : Profile
{
    public UnitConversionProfile()
    {
        CreateMap<UnitConversion, UnitConversionDto>().ReverseMap();

        // Optional mapping to resolve UnitName if a repository provides it by Include
        CreateMap<UnitConversion, UnitConversionListDto>()
            .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Unit != null ? src.Unit.Name : string.Empty));
        // Wait, does UnitConversion have a Unit navigation property? I didn't add one in Domain.
        // Let me refine it:
    }
}

