using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Yonetim;

public class KullaniciRoluListDto : BaseDto
{
    public string RolAdi { get; set; } = string.Empty;
    public string Aciklama { get; set; } = string.Empty;
}
