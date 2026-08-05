using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Domain.Entities.Definitions;
using WinBeyazEsya.Domain.Helpers;

namespace WinBeyazEsya.Application.Mappings.Definitions;

public class TrayProfile : Profile
{
    public TrayProfile()
    {
        CreateMap<Tray, TrayDto>()
            .ReverseMap()
            .ForMember(dest => dest.SpecialCode, opt => opt.Ignore());

        CreateMap<Tray, TrayListDto>()
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : string.Empty))
            .ForMember(dest => dest.TrayTypeName, opt => opt.MapFrom(src => src.TrayType.HasValue ? EnumFunctions.GetDescription(src.TrayType.Value) : string.Empty))
            .ForMember(dest => dest.CoatingTypeName, opt => opt.MapFrom(src => src.CoatingType.HasValue ? EnumFunctions.GetDescription(src.CoatingType.Value) : string.Empty));
    }
}

