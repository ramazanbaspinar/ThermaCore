using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Yonetim;

public class ModulIslemYetkisi : BaseHareketEntity
{
    public long KullaniciRoluId { get; set; }
    public ModulTuru Modul { get; set; }
    
    public byte Gorebilir { get; set; }
    public byte Ekleyebilir { get; set; }
    public byte Degistirebilir { get; set; }
    public byte Silebilir { get; set; }

    public virtual KullaniciRolu KullaniciRolu { get; set; } = null!;
}
