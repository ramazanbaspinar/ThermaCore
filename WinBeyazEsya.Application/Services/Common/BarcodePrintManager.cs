using System.Threading.Tasks;
using WinBeyazEsya.Application.Interfaces.Common;

namespace WinBeyazEsya.Application.Services.Common;

public class BarcodePrintManager : IBarcodePrintService
{
    public Task PrintBarcodeAsync(string barcodeValue, string unit, decimal quantityPerUnit)
    {
        // Mock implementation
        return Task.CompletedTask;
    }
}

