using AutoMapper;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Domain.Entities.Management;

namespace ThermaCore.Application.Mappings.Management;

public class MaliyetParametreProfile : Profile
{
    public MaliyetParametreProfile()
    {
        CreateMap<MaliyetParametre, MaliyetParametreDto>().ReverseMap();
    }
}
