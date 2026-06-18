using ThermaCore.Application.DTOs.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Management;

public class KodSablonDto : BaseDto
{
    public ModuleType Modul { get; set; }
    public string KodOnEk { get; set; } = string.Empty;
    public byte SayisalUzunluk { get; set; }
    public int BaslangicSayisi { get; set; }
    public DateFormat TarihFormati { get; set; }
    public string KodSonEk { get; set; } = string.Empty;
    public bool OtomatikKodUretmeDurumu { get; set; }
    public bool KullaniciMudahalesiDurumu { get; set; }
    public bool FirmaKisaKodKullanimDurumu { get; set; }
    public bool TarihliKodUretmeDurumu { get; set; }
    public bool TarihBazliKodSifrlamaDurumu { get; set; }
}
