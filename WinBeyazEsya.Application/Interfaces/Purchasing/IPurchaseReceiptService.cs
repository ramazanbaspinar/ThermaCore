using WinBeyazEsya.Application.DTOs.Purchasing;

namespace WinBeyazEsya.Application.Interfaces.Purchasing;

public interface IPurchaseReceiptService
{
    PurchaseReceiptDto GetById(long id);
    IEnumerable<PurchaseReceiptListDto> GetAll();
    long Insert(PurchaseReceiptDto dto);
    void Update(PurchaseReceiptDto dto);
    void Delete(long id);
}
