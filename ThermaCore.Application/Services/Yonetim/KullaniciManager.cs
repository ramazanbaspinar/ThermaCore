using System.Linq;
using AutoMapper;
using FluentValidation;
using ThermaCore.Application.DTOs.Yonetim;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Interfaces.Security;
using ThermaCore.Application.Services.Base;
using ThermaCore.Domain.Entities.Yonetim;

namespace ThermaCore.Application.Services.Yonetim;

public class KullaniciManager : BaseMasterManager<KullaniciListDto, KullaniciDto, Kullanici>, IKullaniciService
{
    private readonly ICryptoService _cryptoService;

    public KullaniciManager(
        IMapper mapper, 
        IMasterRepository<Kullanici> repository, 
        IMasterUnitOfWork unitOfWork, 
        IValidator<KullaniciDto> validator,
        ICryptoService cryptoService) 
        : base(mapper, repository, unitOfWork, validator)
    {
        _cryptoService = cryptoService;
    }

    public KullaniciDto? KullaniciGirisYap(string kod, string sifre)
    {
        // Durumu aktif olan ve Kodu eşleşen kullanıcıyı bul
        var kullanici = _repository.Find(k => k.Kod == kod && k.Durum).FirstOrDefault();
        
        if (kullanici == null)
            return null; // Kullanıcı bulunamadı

        var hashedSifre = _cryptoService.EncryptMd5(sifre);
        
        if (kullanici.Sifre == hashedSifre)
        {
            return _mapper.Map<KullaniciDto>(kullanici);
        }

        return null; // Şifre hatalı
    }
}
