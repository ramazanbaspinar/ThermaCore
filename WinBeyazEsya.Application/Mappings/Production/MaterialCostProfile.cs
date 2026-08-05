using AutoMapper;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Application.Mappings.Production;

public class MaterialCostProfile : Profile
{
    public MaterialCostProfile()
    {
        CreateMap<MaterialCost, MaterialCostDto>().ReverseMap();
        
        CreateMap<MaterialCost, MaterialCostListDto>();
    }
}

