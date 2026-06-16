using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Yonetim;

public class KullaniciListDto : BaseDto
{
    public string Adi { get; set; } = string.Empty;
    public string Soyadi { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    
    // KullaniciRolu tablosundan Join ile gelecek
    public string RolAdi { get; set; } = string.Empty; 
}
