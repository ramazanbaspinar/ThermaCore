using System.Collections.Generic;
using System.Threading.Tasks;
using WinBeyazEsya.Application.DTOs.Inventory;

namespace WinBeyazEsya.Application.Interfaces.Services;

public interface IStockTransactionService
{
    Task<List<InventoryStatusListDto>> GetInventoryStatusAsync();
}
