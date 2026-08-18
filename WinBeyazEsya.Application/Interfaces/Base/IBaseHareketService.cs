using System.Collections;

namespace WinBeyazEsya.Application.Interfaces.Base;

public interface IBaseHareketService : IBaseService
{
    bool Insert(IList insertList);
    bool Update(IList updateList);
    bool Delete(IList deleteList);
}

