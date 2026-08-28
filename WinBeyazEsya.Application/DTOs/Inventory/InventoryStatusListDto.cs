using System;

namespace WinBeyazEsya.Application.DTOs.Inventory;

public class InventoryStatusListDto
{
    public long WarehouseId { get; set; }
    public string WarehouseName { get; set; } = string.Empty;
    public long MaterialId { get; set; }
    public string MaterialCode { get; set; } = string.Empty;
    public string MaterialName { get; set; } = string.Empty;
    public string UnitName { get; set; } = string.Empty;
    public decimal TotalIn { get; set; }
    public decimal TotalOut { get; set; }
    public decimal Balance { get; set; }
}
