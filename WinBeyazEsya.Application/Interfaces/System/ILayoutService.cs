namespace WinBeyazEsya.Application.Interfaces.System;

public interface ILayoutService
{
    void SaveLayout(long kullaniciId, string formAdi, string kontrolAdi, string xmlData);
    string GetLayout(long kullaniciId, string formAdi, string kontrolAdi);
    void DeleteLayout(long kullaniciId, string formAdi, string kontrolAdi);
}

