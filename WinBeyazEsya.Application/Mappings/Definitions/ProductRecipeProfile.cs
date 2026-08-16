using System.Linq;
using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Mappings.Definitions;

public class ProductRecipeProfile : Profile
{
    public ProductRecipeProfile()
    {
        CreateMap<ProductRecipe, ProductRecipeDto>()
            .ReverseMap()
            .ForMember(dest => dest.Lines, opt => opt.Ignore());
        
        CreateMap<ProductRecipe, ProductRecipeListDto>()
            .ForMember(dest => dest.FinishedGoodName, opt => opt.MapFrom(src => src.FinishedGood.Name));
            
        CreateMap<ProductRecipeLine, ProductRecipeLineDto>()
            .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Unit.Name))
            .ReverseMap()
            .ForMember(dest => dest.ProductRecipe, opt => opt.Ignore())
            .ForMember(dest => dest.Unit, opt => opt.Ignore());
    }
}
