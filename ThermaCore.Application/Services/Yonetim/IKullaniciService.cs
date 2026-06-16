using System.Collections.Generic;
using ThermaCore.Application.DTOs.Yonetim;

namespace ThermaCore.Application.Services.Yonetim;

public interface IKullaniciService
{
    KullaniciDto GetById(long id);
    IEnumerable<KullaniciListDto> GetAll();
    long Insert(KullaniciDto dto);
    void Update(KullaniciDto dto);
    void Delete(long id);

    KullaniciDto KullaniciGirisYap(string kod, string sifre);
}
