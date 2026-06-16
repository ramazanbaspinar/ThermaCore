using ThermaCore.Application.DTOs.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Yonetim;

public class ModulIslemYetkisiListDto : BaseHareketDto
{
    public long KullaniciRoluId { get; set; }
    public ModulTuru Modul { get; set; }
    
    public byte Gorebilir { get; set; }
    public byte Ekleyebilir { get; set; }
    public byte Degistirebilir { get; set; }
    public byte Silebilir { get; set; }
}
