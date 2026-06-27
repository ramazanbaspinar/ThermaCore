using DevExpress.XtraEditors;
using ThermaCore.Presentation.WinForms.Interfaces;
using System.ComponentModel;

namespace ThermaCore.Presentation.WinForms.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyTextEditPro : TextEdit, IStatusBarAciklama
    {
        public MyTextEditPro()
        {
            // --- İŞLEVSEL AYARLAR ---

            // Veritabanı taşma (overflow) hatalarını engellemek için standart karakter sınırı.
            // İhtiyaç halinde form ekranında bu değer (Properties.MaxLength) o alana özel değiştirilebilir.
            Properties.MaxLength = 100;

            // --- GÖRSEL AYARLAR KALDIRILDI ---
            // Sabit "Segoe UI" fontları ve odaklanıldığında yanan sarı arka plan rengi silindi.
            // DevExpress Skin (Tema) motoru artık bu bileşenin görsel durumlarını otomatik yönetecek.
        }

        // Enter tuşuna basıldığında bir sonraki kontrole (Örn: Ad alanından Soyad alanına) geçişi sağlar.
        public override bool EnterMoveNextControl { get; set; } = true;

        // IStatusBarAciklama Implementasyonu
        // CS8618 uyarısını engellemek ve pragma'dan kurtulmak için string.Empty ataması yapıldı.
        public string StatusBarAciklama { get; set; } = string.Empty;
    }
}