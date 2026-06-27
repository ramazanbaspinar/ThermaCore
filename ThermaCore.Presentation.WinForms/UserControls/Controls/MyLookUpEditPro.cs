using DevExpress.XtraEditors;
using ThermaCore.Presentation.WinForms.Interfaces;
using System.ComponentModel;

namespace ThermaCore.Presentation.WinForms.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyLookUpEditPro : LookUpEdit, IStatusBarKisaYol
    {
        public MyLookUpEditPro()
        {
            // --- İŞLEVSEL AYARLAR ---

            // Bileşen boşken (null) DevExpress'in varsayılan olarak gösterdiği "[EditValue is null]" yazısını temizler.
            Properties.NullText = "";

            // --- GÖRSEL AYARLAR KALDIRILDI ---
            // Sabit "Segoe UI" fontları ve odaklanıldığında yanan sarı arka plan rengi silindi.
            // DevExpress Skin (Tema) motoru artık bu bileşenin görsel durumlarını otomatik yönetecek.
        }

        // Enter tuşuna basıldığında bir sonraki kontrole geçişi sağlar.
        public override bool EnterMoveNextControl { get; set; } = true;

        // IStatusBarKisaYol Implementasyonu
        // CS8618 uyarısını engellemek ve pragma'dan kurtulmak için string.Empty atamaları yapıldı.
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; } = string.Empty;
        public string StatusBarAciklama { get; set; } = string.Empty;
    }
}