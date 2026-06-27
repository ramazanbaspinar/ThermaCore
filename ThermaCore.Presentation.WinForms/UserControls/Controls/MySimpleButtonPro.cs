using DevExpress.XtraEditors;
using ThermaCore.Presentation.WinForms.Interfaces;
using System.ComponentModel;

namespace ThermaCore.Presentation.WinForms.UserControls
{
    [ToolboxItem(true)]
    public class MySimpleButtonPro : SimpleButton, IStatusBarAciklama
    {
        public MySimpleButtonPro()
        {
            // --- GÖRSEL AYARLAR KALDIRILDI ---
            // Butonun Normal, Disabled, Hovered (Üzerine gelindiğinde) ve Pressed (Tıklandığında) durumları için
            // yazılan sabit "Segoe UI" font atamaları silindi. 
            // DevExpress Skin (Tema) motoru artık tüm butonların yazı tipini uygulamanın genel temasına göre otomatik ayarlayacak.
        }

        // IStatusBarAciklama Implementasyonu
        // CS8618 uyarısını engellemek ve pragma'dan kurtulmak için string.Empty ataması yapıldı.
        public string StatusBarAciklama { get; set; } = string.Empty;
    }
}