using AutoMapper;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Domain.Entities.Production;
using WinBeyazEsya.Domain.Extensions;

namespace WinBeyazEsya.Application.Mappings.Production;

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

