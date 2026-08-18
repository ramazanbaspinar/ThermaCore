using DevExpress.XtraEditors;
using System.ComponentModel;
using WinBeyazEsya.Presentation.WinForms.Interfaces;

namespace WinBeyazEsya.Presentation.WinForms.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyCheckEdit : CheckEdit, IStatusBarAciklama
    {
        public MyCheckEdit()
        {
            // --- GÖRSEL AYARLAR KALDIRILDI ---
            // Sabit "Segoe UI" font tanımlamaları ve AppearanceFocused.BackColor (Transparent) ayarı 
            // DevExpress Skin (Tema) motoruna bırakıldı. Onay kutuları artık temanın zemin rengiyle kusursuz bütünleşecek.
        }

        // Enter tuşuna basıldığında bir sonraki kontrole geçişi sağlar.
        public override bool EnterMoveNextControl { get; set; } = true;

        // IStatusBarAciklama Implementasyonu
        // CS8618 uyarısını engellemek ve pragma'dan kurtulmak için string.Empty ataması yapıldı.
        public string StatusBarAciklama { get; set; } = string.Empty;
    }
}
