using DevExpress.Utils;
using System.ComponentModel;

namespace ThermaCore.Presentation.WinForms.UserControls
{
    [ToolboxItem(true)]
    public class MyKodTextEditPro : MyTextEditPro // Ana metin kutusu sınıfımızın "Pro" versiyonundan miras alıyoruz
    {
        public MyKodTextEditPro()
        {
            // --- İŞLEVSEL AYARLAR ---

            // Kod alanları (Cari kodu, Stok kodu vs.) genellikle kısa ve formatlı olduğu için 
            // metnin ortalanması veri giriş ekranlarında profesyonel bir görünüm ve kolay okunabilirlik sağlar.
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;

            // Durum çubuğu (StatusBar) bilgi mesajı
            StatusBarAciklama = "Kod Giriniz.";

            // --- GÖRSEL AYARLAR KALDIRILDI ---
            // Sabit açık mavi (220, 235, 250) arka plan rengi silindi.
            // DevExpress Skin (Tema) motoru artık koyu/açık formlara göre bu alanı otomatik renklendirecek.
        }
    }
}