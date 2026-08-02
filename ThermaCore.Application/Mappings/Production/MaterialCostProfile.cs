using AutoMapper;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Mappings.Production;

public class MaterialCostProfile : Profile
{
    public MaterialCostProfile()
    {
        CreateMap<MaterialCost, MaterialCostDto>().ReverseMap();
        
        CreateMap<MaterialCost, MaterialCostListDto>();
    }
}
