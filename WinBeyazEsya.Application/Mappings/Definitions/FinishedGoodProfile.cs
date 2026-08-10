using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Mappings.Definitions;

public class FinishedGoodProfile : Profile
{
    public FinishedGoodProfile()
    {
        CreateMap<FinishedGood, FinishedGoodDto>()
            .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Unit != null ? src.Unit.Name : string.Empty))
            .ReverseMap()
            .ForMember(dest => dest.Unit, opt => opt.Ignore())
            .ForMember(dest => dest.SpecialCode, opt => opt.Ignore());
            
        CreateMap<FinishedGood, FinishedGoodListDto>()
            .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Unit != null ? src.Unit.Name : string.Empty))
            .ForMember(dest => dest.GroupName, opt => opt.Ignore()) // GroupName and PrimaryBarcode might be handled in the manager or a custom mapping logic if needed
            .ForMember(dest => dest.PrimaryBarcode, opt => opt.Ignore()); 
    }
}
