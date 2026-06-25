using ThermaCore.Application.DTOs.Base;

namespace ThermaCore.Application.DTOs.Definitions;

public class ItemCategoryDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public long? ParentId { get; set; }
    public string? Description { get; set; }
}
