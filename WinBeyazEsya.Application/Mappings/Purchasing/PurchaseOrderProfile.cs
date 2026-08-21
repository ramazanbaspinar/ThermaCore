using AutoMapper;
using WinBeyazEsya.Application.DTOs.Purchasing;
using WinBeyazEsya.Domain.Entities.Purchasing;

namespace WinBeyazEsya.Application.Mappings.Purchasing;

public class PurchaseOrderProfile : Profile
{
    public PurchaseOrderProfile()
    {
        CreateMap<PurchaseOrder, PurchaseOrderDto>().ReverseMap();
        
        CreateMap<PurchaseOrder, PurchaseOrderListDto>();
        
        CreateMap<PurchaseOrderLine, PurchaseOrderLineDto>()
            .ForMember(dest => dest.CurrencyCode, opt => opt.Ignore());
            
        CreateMap<PurchaseOrderLineDto, PurchaseOrderLine>();
    }
}
