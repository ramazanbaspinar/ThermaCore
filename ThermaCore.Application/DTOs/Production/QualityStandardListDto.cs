using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.DTOs.Production;

public class QualityStandardListDto
{
    public long Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public MaterialGroup MaterialGroup { get; set; }
    public string MaterialGroupName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
