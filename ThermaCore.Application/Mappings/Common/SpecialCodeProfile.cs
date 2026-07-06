using AutoMapper;
using ThermaCore.Application.DTOs.Common;
using ThermaCore.Domain.Entities.Common;

namespace ThermaCore.Application.Mappings.Common;

public class SpecialCodeProfile : Profile
{
    public SpecialCodeProfile()
    {
        CreateMap<SpecialCode, SpecialCodeDto>().ReverseMap();
    }
}
