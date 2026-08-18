using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class WarehouseDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string AuthorizedPerson { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
