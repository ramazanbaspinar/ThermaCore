using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Definitions
{
    public class PlasticPartListDto : BaseDto
    {
        // Kural gereği Id, Code, IsActive özellikleri BaseListDto'dan miras alınacak ve gizlenmeyecek.
        
        public string Name { get; set; } = default!;
        public string BaseUnit { get; set; } = default!;
        
        public string? SpecialCode { get; set; }
        
        public string? PlasticPartCategory { get; set; }
        public string? PlasticMaterialType { get; set; }
        
        public string? Color { get; set; }
        public decimal? WeightGr { get; set; }
        public string? Description { get; set; }
    }
}
