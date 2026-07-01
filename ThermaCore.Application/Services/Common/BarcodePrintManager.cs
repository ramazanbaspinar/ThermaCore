using System.Threading.Tasks;
using ThermaCore.Application.Interfaces.Common;

namespace ThermaCore.Application.Services.Common;

public class BarcodePrintManager : IBarcodePrintService
{
    public Task PrintBarcodeAsync(string barcodeValue, string unit, decimal quantityPerUnit)
    {
        // Mock implementation
        return Task.CompletedTask;
    }
}
