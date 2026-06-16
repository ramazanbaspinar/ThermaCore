using System.ComponentModel.DataAnnotations;
using ThermaCore.Domain.Entities.Base;

namespace ThermaCore.Domain.Entities.Yonetim;

public class Terminal : BaseEntity
{
    [MaxLength(50)]
    public string MacAdresi { get; set; } = string.Empty;

    [MaxLength(50)]
    public string IpAdresi { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Aciklama { get; set; } = string.Empty;

    [MaxLength(200)]
    public string DonanimParmakIzi { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string LisansAnahtari { get; set; } = string.Empty;

    public DateTime? SonGirisTarihi { get; set; }
}
