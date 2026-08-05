using AutoMapper;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Application.Mappings.Production;

public class GasPipeProfile : Profile
{
    public GasPipeProfile()
    {
        CreateMap<GasPipe, GasPipeDto>()
            .ReverseMap()
            .ForMember(dest => dest.SpecialCode, opt => opt.Ignore());

        CreateMap<GasPipe, GasPipeListDto>()
            .ReverseMap()
            .ForMember(dest => dest.SpecialCode, opt => opt.Ignore());
    }
}

