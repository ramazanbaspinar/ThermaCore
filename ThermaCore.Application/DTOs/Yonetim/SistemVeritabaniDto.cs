using ThermaCore.Application.DTOs.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Yonetim;

public class SistemVeritabaniDto : BaseDto
{
    public string FirmaKodu { get; set; } = string.Empty;
    public string FirmaAdi { get; set; } = string.Empty;
    public string VeritabaniAdi { get; set; } = string.Empty;
    public string Server { get; set; } = string.Empty;
    public YetkilendirmeTuru YetkilendirmeTuru { get; set; }
    public string? KullaniciAdi { get; set; }
    public string? Sifre { get; set; }
}
