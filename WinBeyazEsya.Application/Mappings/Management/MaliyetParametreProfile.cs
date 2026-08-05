using AutoMapper;
using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Domain.Entities.Management;

namespace WinBeyazEsya.Application.Mappings.Management;

public class MaliyetParametreProfile : Profile
{
    public MaliyetParametreProfile()
    {
        CreateMap<MaliyetParametre, MaliyetParametreDto>().ReverseMap();
    }
}

