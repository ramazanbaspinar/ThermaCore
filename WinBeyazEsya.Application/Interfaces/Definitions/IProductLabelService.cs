using System.Collections.Generic;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IProductLabelService
{
    IEnumerable<ProductLabelListDto> GetAll();
    ProductLabelDto GetById(long id);
    long Insert(ProductLabelDto dto);
    void Update(ProductLabelDto dto);
    void Delete(long id);
}

