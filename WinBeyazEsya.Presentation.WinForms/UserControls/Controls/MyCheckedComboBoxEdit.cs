using DevExpress.XtraEditors;
using System.ComponentModel;
using WinBeyazEsya.Presentation.WinForms.Interfaces;

namespace WinBeyazEsya.Presentation.WinForms.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyCheckedComboBoxEdit : CheckedComboBoxEdit, IStatusBarKisaYol
    {
        public MyCheckedComboBoxEdit()
        {
            // --- GÖRSEL AYARLAR KALDIRILDI ---
            // Sabit "Segoe UI" font tanımlamaları ve AppearanceFocused.BackColor (Sarı renk) 
            // DevExpress Skin (Tema) motoruna bırakıldı. Böylece sistemin kalanıyla tam uyumlu çalışacak.
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
