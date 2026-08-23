using AutoMapper;
using WinBeyazEsya.Application.DTOs.Inventory;
using WinBeyazEsya.Domain.Entities.Inventory;

namespace WinBeyazEsya.Application.Mappings.Inventory;

public class StockTransactionProfile : Profile
{
    public StockTransactionProfile()
    {
        CreateMap<StockTransaction, StockTransactionDto>().ReverseMap();
    }
}
