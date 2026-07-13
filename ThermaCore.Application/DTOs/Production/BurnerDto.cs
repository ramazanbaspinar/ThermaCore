using ThermaCore.Application.DTOs.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Production
{
    public class BurnerDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string BaseUnit { get; set; } = string.Empty;
        public BurnerType? BurnerType { get; set; }
        public decimal? SizeMm { get; set; }
        public decimal? PowerKw { get; set; }
        public string? CapType { get; set; }
        public string? Description { get; set; }
        public long? SpecialCodeId { get; set; }
    }
}
