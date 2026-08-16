using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Mappings.Definitions;

public class CurrentAccountProfile : Profile
{
    public CurrentAccountProfile()
    {
        CreateMap<CurrentAccountDto, CurrentAccount>().ReverseMap();
    }
}
