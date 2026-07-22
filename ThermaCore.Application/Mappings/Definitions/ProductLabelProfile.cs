using AutoMapper;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Application.Mappings.Definitions;

public class ProductLabelProfile : Profile
{
    public ProductLabelProfile()
    {
        CreateMap<ProductLabel, ProductLabelDto>().ReverseMap();
        CreateMap<ProductLabel, ProductLabelListDto>().ReverseMap();
    }
}
