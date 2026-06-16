using System.ComponentModel.DataAnnotations;
using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Yonetim;

public class SistemVeritabani : BaseEntity
{
    [Required, MaxLength(10)]
    public string FirmaKodu { get; set; } = string.Empty;
    
    [Required, MaxLength(200)]
    public string FirmaAdi { get; set; } = string.Empty;
    
    [Required, MaxLength(100)]
    public string VeritabaniAdi { get; set; } = string.Empty;
    
    [Required, MaxLength(100)]
    public string Server { get; set; } = string.Empty;
    
    public YetkilendirmeTuru YetkilendirmeTuru { get; set; }
    
    [MaxLength(100)]
    public string? KullaniciAdi { get; set; }
    
    [MaxLength(1000)]
    public string? Sifre { get; set; }
}
