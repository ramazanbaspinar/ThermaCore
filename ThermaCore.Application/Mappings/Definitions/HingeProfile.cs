using AutoMapper;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Application.Mappings.Definitions;

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
