using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Mappings.Definitions;

public class WarehouseProfile : Profile
{
    public WarehouseProfile()
    {
        CreateMap<WarehouseDto, Warehouse>().ReverseMap();
        CreateMap<Warehouse, WarehouseListDto>();
    }
}
