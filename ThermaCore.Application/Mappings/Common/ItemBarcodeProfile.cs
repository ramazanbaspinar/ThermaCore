using AutoMapper;
using ThermaCore.Application.DTOs.Common;
using ThermaCore.Domain.Entities.Common;

namespace ThermaCore.Application.Mappings.Common;

public class ItemBarcodeProfile : Profile
{
    public ItemBarcodeProfile()
    {
        CreateMap<ItemBarcode, ItemBarcodeDto>().ReverseMap();
        CreateMap<ItemBarcode, ItemBarcodeListDto>().ReverseMap();
    }
}
