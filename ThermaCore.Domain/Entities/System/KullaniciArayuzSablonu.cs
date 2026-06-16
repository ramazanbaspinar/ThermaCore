using System.ComponentModel.DataAnnotations;
using ThermaCore.Domain.Entities.Base;

namespace ThermaCore.Domain.Entities.System;

public class KullaniciArayuzSablonu : BaseEntity
{
    public long KullaniciId { get; set; }
    
    [MaxLength(100)]
    public string FormAdi { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string KontrolAdi { get; set; } = string.Empty;
    
    public string XmlVerisi { get; set; } = string.Empty;
}
