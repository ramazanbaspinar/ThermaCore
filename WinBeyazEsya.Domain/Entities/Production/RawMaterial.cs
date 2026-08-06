using System;
using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Domain.Entities.Production;

public class RawMaterial : FullAuditableEntity
{
    // --- Standart Alanlar ---
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public long? BaseUnitId { get; set; } // BirimTanimlari tablosuna FK
    public string? Image { get; set; }
    public string? Description { get; set; }
    
    // --- Discriminator (TPH için) ---
    public MaterialGroup MaterialGroup { get; set; }

    // --- Esneklik Alanları (Custom Fields) ---
    public string? CustomCode1 { get; set; }
    public string? CustomCode2 { get; set; }
    public string? CustomCode3 { get; set; }
    public string? CustomCode4 { get; set; }
    public string? CustomCode5 { get; set; }

    // --- Gruba Özel Alanlar (İlgisiz gruplarda NULL kalacak) ---
    public string? SurfaceType { get; set; }
    public string? QualityCode { get; set; }
    public string? Dimensions { get; set; } // En/Boy/Kalınlık veya formatlı string
    public string? Material { get; set; }
    public string? Coating { get; set; }
}
