using AutoMapper;
using WinBeyazEsya.Application.DTOs.Purchasing;
using WinBeyazEsya.Domain.Entities.Purchasing;

namespace WinBeyazEsya.Application.Mappings.Purchasing;

public class PurchaseReceiptProfile : Profile
{
    public PurchaseReceiptProfile()
    {
        CreateMap<PurchaseReceipt, PurchaseReceiptDto>().ReverseMap();

        CreateMap<PurchaseReceipt, PurchaseReceiptListDto>();

        CreateMap<PurchaseReceiptLine, PurchaseReceiptLineDto>().ReverseMap();
    }
}
