using DevExpress.XtraEditors;

namespace WinBeyazEsya.Presentation.WinForms.Helpers;

public static class Messages
{
    public static void HataMesaji(string hataMesaji)
    {
        XtraMessageBox.Show(hataMesaji, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static void UyariMesaji(string mesaj)
    {
        XtraMessageBox.Show(mesaj, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    public static void BilgiMesaji(string mesaj)
    {
        XtraMessageBox.Show(mesaj, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static DialogResult SilMesaj(string tabloAdi)
    {
        return XtraMessageBox.Show($"Seçili {tabloAdi} kayıtları silinecektir. Onaylıyor musunuz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
    }

    public static DialogResult EvetSeciliEvetHayir(string mesaj, string baslik)
    {
        return XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
    }

    public static DialogResult HayirSeciliEvetHayir(string mesaj, string baslik)
    {
        return XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
    }

    public static DialogResult EvetSeciliEvetHayirIptal(string mesaj, string baslik)
    {
        return XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
    }

    public static DialogResult KayitMesaj()
    {
        return EvetSeciliEvetHayir("Kaydetmek İstiyor Musunuz?", "Kayıt Onayı");
    }

    public static DialogResult KapanisMesaj()
    {
        return EvetSeciliEvetHayirIptal("Kapatırken Değişiklikler Kaydedilsin Mi?", "Kapanış Onayı");
    }

    public static void KayitBasariliMesaji()
    {
        XtraMessageBox.Show("Kayıt işlemi başarıyla tamamlandı.", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static void GuncellemeMesaj()
    {
        XtraMessageBox.Show("Güncelleme işlemi başarıyla tamamlandı.", "Güncelleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static void SilindiMesaj()
    {
        XtraMessageBox.Show("Kayıt başarıyla silindi.", "Silme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static void HataBasligi(string mesaj, string baslik)
    {
        XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static void UyariBasligi(string mesaj, string baslik)
    {
        XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    public static void BilgiBasligi(string mesaj, string baslik)
    {
        XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static void MusteriHataMesaji(string mesaj)
    {
        XtraMessageBox.Show($"Müşteri işleminde hata: {mesaj}", "Müşteri Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static DialogResult YazdirMesaj(string mesaj)
    {
        return XtraMessageBox.Show(mesaj, "Yazdırma Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
    }

    public static DialogResult KapatMesaj()
    {
        return XtraMessageBox.Show("Programdan çıkmak istiyor musunuz?", "Çıkış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
    }

    public static void SifreHatasiMesaji()
    {
        XtraMessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    public static void YetkisizGirisMesaji()
    {
        XtraMessageBox.Show("Bu işlem için yetkiniz bulunmamaktadır.", "Yetkisiz İşlem", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

