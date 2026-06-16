using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Yonetim;

public class KullaniciDto : BaseDto
{
    public string Adi { get; set; } = string.Empty;
    public string Soyadi { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Sifre { get; set; } = string.Empty;
    
    public long KullaniciRoluId { get; set; }
    public string RolAdi { get; set; } = string.Empty;
}
