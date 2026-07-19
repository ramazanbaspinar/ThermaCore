using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Entities.Common;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Definitions
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
