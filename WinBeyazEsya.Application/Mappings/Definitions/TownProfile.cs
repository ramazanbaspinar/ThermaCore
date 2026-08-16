using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Mappings.Definitions;

public class TownProfile : Profile
{
    public TownProfile()
    {
        CreateMap<TownDto, Town>().ReverseMap();
    }
}
