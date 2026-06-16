using System.ComponentModel.DataAnnotations;
using ThermaCore.Domain.Entities.Base;

namespace ThermaCore.Domain.Entities.Yonetim;

public class Kullanici : BaseEntity
{
    [MaxLength(50)]
    public string Adi { get; set; } = string.Empty;

    [MaxLength(50)]
    public string Soyadi { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Sifre { get; set; } = string.Empty;

    public long KullaniciRoluId { get; set; }

    public virtual KullaniciRolu KullaniciRolu { get; set; } = null!;
}
