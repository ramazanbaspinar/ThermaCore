using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Entities.Common;
using ThermaCore.Domain.Entities.Definitions;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Production
{
    public class Burner : FullAuditableEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string BaseUnit { get; set; } = string.Empty;
        public BurnerType? BurnerType { get; set; }
        public decimal? SizeMm { get; set; }
        public decimal? PowerKw { get; set; }
        public string? CapType { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        public long? SpecialCodeId { get; set; }
        public SpecialCode? SpecialCode { get; set; }
    }
}
