using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Entities.Common;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Domain.Entities.Definitions
{
    public class PlasticPart : FullAuditableEntity
    {
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string BaseUnit { get; set; } = default!;
        
        public long? SpecialCodeId { get; set; }
        public SpecialCode? SpecialCode { get; set; }
        
        public PlasticPartCategory? PlasticPartCategory { get; set; }
        public PlasticMaterialType? PlasticMaterialType { get; set; }
        
        public string? Color { get; set; }
        public decimal? WeightGr { get; set; }
        public string? Description { get; set; }
        
        // Zırhlı Kural
        public bool IsActive { get; set; } = true;
    }
}

