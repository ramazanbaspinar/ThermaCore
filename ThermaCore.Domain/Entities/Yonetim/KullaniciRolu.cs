using System.ComponentModel.DataAnnotations;
using ThermaCore.Domain.Entities.Base;

namespace ThermaCore.Domain.Entities.Yonetim;

public class KullaniciRolu : BaseEntity
{
    [Required]
    [MaxLength(50)]
    public string RolAdi { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Aciklama { get; set; } = string.Empty;
}
