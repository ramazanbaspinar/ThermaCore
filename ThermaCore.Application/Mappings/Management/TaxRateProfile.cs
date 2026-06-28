using AutoMapper;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Domain.Entities.Management;

namespace ThermaCore.Application.Mappings.Management;

public class TaxRateProfile : Profile
{
    public TaxRateProfile()
    {
        CreateMap<TaxRate, TaxRateDto>().ReverseMap();
        CreateMap<TaxRate, TaxRateListDto>();
    }
}
