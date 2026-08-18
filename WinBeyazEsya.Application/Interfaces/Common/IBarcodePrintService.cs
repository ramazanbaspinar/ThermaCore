namespace WinBeyazEsya.Application.Interfaces.Common;

public interface IBarcodePrintService
{
    Task PrintBarcodeAsync(string barcodeValue, string unit, decimal quantityPerUnit);
}

