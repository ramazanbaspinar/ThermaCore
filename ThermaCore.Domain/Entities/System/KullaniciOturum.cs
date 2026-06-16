using System;
using System.ComponentModel.DataAnnotations;
using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.System;

public class KullaniciOturum : BaseHareketEntity
{
    public long KullaniciId { get; set; }
    public DateTime GirisZamani { get; set; }
    public DateTime? CikisZamani { get; set; }
    
    [MaxLength(50)]
    public string IpAdresi { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string BilgisayarAdi { get; set; } = string.Empty;
    
    public OturumDurumu Durum { get; set; }
}
