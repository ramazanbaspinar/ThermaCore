using DevExpress.XtraEditors;
using WinBeyazEsya.Presentation.WinForms.Interfaces;
using System.ComponentModel;

namespace WinBeyazEsya.Presentation.WinForms.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyFilterControl : FilterControl, IStatusBarAciklama
    {
        public MyFilterControl()
        {
            // --- İŞLEVSEL AYARLAR ---

            // Filtre gruplarında (Ve/Veya operatörleri gibi) komut ikonlarının gösterilmesini sağlar. 
            // Kullanıcının karmaşık sorguları daha rahat okumasına ve yönetmesine yardımcı olur.
            ShowGroupCommandsIcon = true;

            // --- GÖRSEL AYARLAR KALDIRILDI ---
            // Sabit "Segoe UI" font tanımlaması silindi. Kontrolün metin boyutları ve tipleri 
            // artık formun genel DevExpress temasından (Skin) otomatik olarak devralınacak.
        }

        // IStatusBarAciklama Implementasyonu
        // Başlangıç değeri atandığı için CS8618 uyarısı zaten oluşmaz.
        public string StatusBarAciklama { get; set; } = "Filtre Metni Giriniz.";
    }
}
