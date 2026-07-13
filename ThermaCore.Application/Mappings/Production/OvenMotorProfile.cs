using AutoMapper;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Domain.Entities.Production;
using ThermaCore.Domain.Extensions;

namespace ThermaCore.Application.Mappings.Production;

public class OvenMotorProfile : Profile
{
    public OvenMotorProfile()
    {
        CreateMap<OvenMotor, OvenMotorDto>().ReverseMap();
        
        CreateMap<OvenMotor, OvenMotorListDto>()
            .ForMember(dest => dest.MotorTypeName, opt => opt.MapFrom(src => src.MotorType.HasValue ? src.MotorType.Value.ToName() : null))
            .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Name : null));
    }
}
