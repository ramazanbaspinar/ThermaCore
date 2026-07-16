using AutoMapper;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Domain.Entities.Definitions;
using ThermaCore.Domain.Helpers;

namespace ThermaCore.Application.Mappings.Definitions;

public class GridProfile : Profile
{
    public GridProfile()
    {
        CreateMap<Grid, GridDto>()
            .ReverseMap()
            .ForMember(dest => dest.SpecialCode, opt => opt.Ignore());

        CreateMap<Grid, GridListDto>()
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : string.Empty))
            .ForMember(dest => dest.GridTypeName, opt => opt.MapFrom(src => src.GridType.HasValue ? EnumFunctions.GetDescription(src.GridType.Value) : string.Empty));
    }
}
