using AutoMapper;
using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Domain.Entities.Management;

namespace WinBeyazEsya.Application.Mappings.Management;

public class SystemParameterProfile : Profile
{
    public SystemParameterProfile()
    {
        CreateMap<SystemParameter, SystemParameterDto>().ReverseMap();
    }
}

