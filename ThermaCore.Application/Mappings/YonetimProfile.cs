using AutoMapper;
using ThermaCore.Domain.Entities.Yonetim;
using ThermaCore.Application.DTOs.Yonetim;

namespace ThermaCore.Application.Mappings;

public class YonetimProfile : Profile
{
    public YonetimProfile()
    {
        CreateMap<KullaniciRolu, KullaniciRoluDto>().ReverseMap();
        CreateMap<KullaniciRolu, KullaniciRoluListDto>();

        CreateMap<Kullanici, KullaniciDto>()
            .ForMember(x => x.RolAdi, opt => opt.MapFrom(src => src.KullaniciRolu.RolAdi))
            .ReverseMap();

        CreateMap<Kullanici, KullaniciListDto>()
            .ForMember(x => x.RolAdi, opt => opt.MapFrom(src => src.KullaniciRolu.RolAdi));

        CreateMap<ModulIslemYetkisi, ModulIslemYetkisiListDto>().ReverseMap();
        CreateMap<KullaniciBazliModulIslemYetkisi, KullaniciBazliModulIslemYetkisiListDto>().ReverseMap();
        
        CreateMap<Terminal, TerminalDto>().ReverseMap();
        CreateMap<Terminal, TerminalListDto>();
    }
}
