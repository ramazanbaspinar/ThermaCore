using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ThermaCore.Presentation.WinForms.Interfaces;
using System.ComponentModel;

namespace ThermaCore.Presentation.WinForms.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyComboBoxEditPro : ComboBoxEdit, IStatusBarKisaYol
    {
        public MyComboBoxEditPro()
        {
            // --- İŞLEVSEL AYARLAR ---
            // Kullanıcının listeye serbest metin girmesini engeller, sadece listedeki öğelerin seçilmesini zorunlu kılar.
            // ERP sistemlerinde veri tutarlılığı için bu ayar standarttır.
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            // --- GÖRSEL AYARLAR KALDIRILDI ---
            // Odaklanma rengi (sarı) ve 9 farklı yerdeki statik Segoe UI font atamaları silindi.
            // DevExpress Skin (Tema) motoru artık bu listeyi otomatik yönetecek.
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