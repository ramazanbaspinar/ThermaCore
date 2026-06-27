#pragma warning disable CS8618
using DevExpress.Utils;
using DevExpress.XtraEditors;
using ThermaCore.Presentation.WinForms.Interfaces;
using System.ComponentModel;

namespace ThermaCore.Presentation.WinForms.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyCalcEdit : CalcEdit, IStatusBarKisaYol
    {
        public MyCalcEdit()
        {
            // --- İŞLEVSEL AYARLAR ---

            // Kullanıcının alanı boş (null) bırakmasını engeller, varsayılan olarak 0 veya girilen değeri tutar.
            Properties.AllowNullInput = DefaultBoolean.False;

            // Sayısal formatlama (Örn: 1.234,56). Virgülden sonra 2 hane gösterimi finans/stok için korunmuştur.
            Properties.DisplayFormat.FormatType = FormatType.Numeric;
            Properties.DisplayFormat.FormatString = "n2";
            Properties.EditFormat.FormatType = FormatType.Numeric;
            Properties.EditFormat.FormatString = "n2";
            Properties.EditMask = "n2";
            Properties.Mask.UseMaskAsDisplayFormat = true;

            // --- GÖRSEL AYARLAR KALDIRILDI ---
            // Sabit Font tanımlamaları ve AppearanceFocused.BackColor (Sarı renk) DevExpress Skin (Tema) motoruna bırakıldı.
        }

        // Enter tuşuna basıldığında bir sonraki kontrole geçişi sağlar.
        public override bool EnterMoveNextControl { get; set; } = true;

        // IStatusBarKisaYol Implementasyonu
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; } = "Hesap Makinesi";
        public string StatusBarAciklama { get; set; }
    }
}