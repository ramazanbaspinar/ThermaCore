using AutoMapper;
using WinBeyazEsya.Application.DTOs.Common;
using WinBeyazEsya.Domain.Entities.Common;

namespace WinBeyazEsya.Application.Mappings.Common;

public class SpecialCodeProfile : Profile
{
    public SpecialCodeProfile()
    {
        CreateMap<SpecialCode, SpecialCodeDto>().ReverseMap();
    }
}

