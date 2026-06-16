using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Yonetim;

public class SistemVeritabaniListDto
{
    public long Id { get; set; }
    public string Kod { get; set; } = string.Empty;
    public bool Durum { get; set; }
    
    public string FirmaKodu { get; set; } = string.Empty;
    public string FirmaAdi { get; set; } = string.Empty;
    public string VeritabaniAdi { get; set; } = string.Empty;
    public string Server { get; set; } = string.Empty;
    public YetkilendirmeTuru YetkilendirmeTuru { get; set; }
}
