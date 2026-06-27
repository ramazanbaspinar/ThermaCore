using DevExpress.XtraEditors;
using ThermaCore.Presentation.WinForms.Interfaces;
using System.ComponentModel;

namespace ThermaCore.Presentation.WinForms.UserControls
{
    [ToolboxItem(true)]
    public class MyFilterControlPro : FilterControl, IStatusBarAciklama
    {
        public MyFilterControlPro()
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