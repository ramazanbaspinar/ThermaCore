using DevExpress.XtraEditors;
using System.ComponentModel;
using WinBeyazEsya.Presentation.WinForms.Interfaces;

namespace WinBeyazEsya.Presentation.WinForms.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MySimpleButton : SimpleButton, IStatusBarAciklama
    {
        public MySimpleButton()
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
