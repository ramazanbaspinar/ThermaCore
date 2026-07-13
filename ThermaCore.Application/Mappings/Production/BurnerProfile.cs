using AutoMapper;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Domain.Entities.Production;
using ThermaCore.Domain.Extensions;

namespace ThermaCore.Application.Mappings.Production
{
    public class BurnerProfile : Profile
    {
        public BurnerProfile()
        {
            CreateMap<Burner, BurnerDto>().ReverseMap();
            
            CreateMap<Burner, BurnerListDto>()
                .ForMember(dest => dest.BurnerTypeName, opt => opt.MapFrom(src => src.BurnerType.HasValue ? src.BurnerType.Value.ToName() : string.Empty))
                .ForMember(dest => dest.SpecialCodeName, opt => opt.MapFrom(src => src.SpecialCode != null ? src.SpecialCode.Code : string.Empty));
        }
    }
}
