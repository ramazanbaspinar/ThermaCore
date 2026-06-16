using System.Collections.Generic;
using ThermaCore.Application.DTOs.Yonetim;

namespace ThermaCore.Application.Services.Yonetim;

public interface IKullaniciRoluService
{
    KullaniciRoluDto GetById(long id);
    IEnumerable<KullaniciRoluListDto> GetAll();
    long Insert(KullaniciRoluDto dto);
    void Update(KullaniciRoluDto dto);
    void Delete(long id);
}
