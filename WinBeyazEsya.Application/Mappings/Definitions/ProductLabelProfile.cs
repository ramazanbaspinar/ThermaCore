using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Mappings.Definitions;

public class ProductLabelProfile : Profile
{
    public ProductLabelProfile()
    {
        CreateMap<ProductLabel, ProductLabelDto>().ReverseMap();
        CreateMap<ProductLabel, ProductLabelListDto>().ReverseMap();
    }
}

