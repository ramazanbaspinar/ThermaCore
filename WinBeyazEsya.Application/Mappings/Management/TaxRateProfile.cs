using AutoMapper;
using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Domain.Entities.Management;

namespace WinBeyazEsya.Application.Mappings.Management;

public class TaxRateProfile : Profile
{
    public TaxRateProfile()
    {
        CreateMap<TaxRate, TaxRateDto>().ReverseMap();
        CreateMap<TaxRate, TaxRateListDto>();
    }
}

