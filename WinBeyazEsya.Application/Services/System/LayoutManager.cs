using WinBeyazEsya.Application.Interfaces.System;

namespace WinBeyazEsya.Application.Services.System;

public class LayoutManager : ILayoutService
{
    public void SaveLayout(long kullaniciId, string formAdi, string kontrolAdi, string xmlData)
    {
        // DevExpress XML layout veritabanı kayıt işlemi
    }

    public string GetLayout(long kullaniciId, string formAdi, string kontrolAdi)
    {
        // Veritabanından XML layout geri yükleme işlemi
        return string.Empty;
    }

    public void DeleteLayout(long kullaniciId, string formAdi, string kontrolAdi)
    {
        // Silme işlemi
    }
}

