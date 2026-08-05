using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Mappings.Definitions;

public class HingeProfile : Profile
{
    public HingeProfile()
    {
        CreateMap<Hinge, HingeDto>()
            .ReverseMap()
            .ForMember(dest => dest.SpecialCodeId, opt => opt.Ignore());

        CreateMap<Hinge, HingeListDto>();
    }
}

