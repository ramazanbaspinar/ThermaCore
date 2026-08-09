using AutoMapper;
using WinBeyazEsya.Application.DTOs.Common;
using WinBeyazEsya.Domain.Entities.Common;

namespace WinBeyazEsya.Application.Mappings.Common;

public class ItemBarcodeProfile : Profile
{
    public ItemBarcodeProfile()
    {
        CreateMap<ItemBarcode, ItemBarcodeDto>().ReverseMap();
        CreateMap<ItemBarcode, ItemBarcodeListDto>()
            .ForMember(dest => dest.IsActive, opt => opt.Ignore())
            .ReverseMap();
        CreateMap<ItemBarcodeListDto, ItemBarcodeDto>().ReverseMap();
    }
}

