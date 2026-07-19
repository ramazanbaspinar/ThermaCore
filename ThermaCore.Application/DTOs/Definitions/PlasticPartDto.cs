using ThermaCore.Application.DTOs.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Definitions
{
    public class PlasticPartDto : BaseDto
    {
        // Kural gereği Id, Code, IsActive özellikleri BaseDto'dan miras alınacak ve gizlenmeyecek.
        
        public string Name { get; set; } = default!;
        public string BaseUnit { get; set; } = default!;
        
        public long? SpecialCodeId { get; set; }
        
        public PlasticPartCategory? PlasticPartCategory { get; set; }
        public PlasticMaterialType? PlasticMaterialType { get; set; }
        
        public string? Color { get; set; }
        public decimal? WeightGr { get; set; }
        public string? Description { get; set; }
    }
}
