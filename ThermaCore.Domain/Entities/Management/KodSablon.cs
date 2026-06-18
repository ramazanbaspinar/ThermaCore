using System.ComponentModel.DataAnnotations;
using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Management;

public class KodSablon : FullAuditableEntity
{
    [Required]
    public ModuleType Modul { get; set; }

    [Required]
    [StringLength(100)]
    public string KodOnEk { get; set; } = string.Empty;

    [Required]
    public byte SayisalUzunluk { get; set; }

    [Required]
    public int BaslangicSayisi { get; set; }

    [Required]
    public DateFormat TarihFormati { get; set; }

    [StringLength(100)]
    public string KodSonEk { get; set; } = string.Empty;

    public bool OtomatikKodUretmeDurumu { get; set; }
    public bool KullaniciMudahalesiDurumu { get; set; }
    public bool FirmaKisaKodKullanimDurumu { get; set; }
    public bool TarihliKodUretmeDurumu { get; set; }
    public bool TarihBazliKodSifrlamaDurumu { get; set; }
}
