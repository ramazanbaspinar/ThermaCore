using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Yonetim;

public class TerminalDto : BaseDto
{
    public string MacAdresi { get; set; } = string.Empty;
    public string IpAdresi { get; set; } = string.Empty;
    public string Aciklama { get; set; } = string.Empty;

    public string DonanimParmakIzi { get; set; } = string.Empty;
    public string LisansAnahtari { get; set; } = string.Empty;
    public DateTime? SonGirisTarihi { get; set; }
}
