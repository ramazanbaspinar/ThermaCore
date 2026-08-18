using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Base;

namespace WinBeyazEsya.Application.Interfaces.Definitions;

public interface IProductRecipeService : IBaseService
{
    ProductRecipeDto GetById(long id);
    IEnumerable<ProductRecipeListDto> GetAll();
    long Insert(ProductRecipeDto dto);
    void Update(ProductRecipeDto dto);
    void Delete(long id);
    bool IsCodeUnique(long id, string code);
}
