using AutoMapper;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Domain.Entities.Management;

namespace ThermaCore.Application.Mappings.Management;

public class SystemParameterProfile : Profile
{
    public SystemParameterProfile()
    {
        CreateMap<SystemParameter, SystemParameterDto>().ReverseMap();
    }
}
