using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using System.ComponentModel;

namespace WinBeyazEsya.Presentation.WinForms.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyCardEdit : MyTextEdit // Eğer önceki adımlarda MyTextEditPro oluşturduysan ondan miras almalısın.
    {
        public MyCardEdit()
        {
            // --- İŞLEVSEL AYARLAR ---

            // Kredi kartı numaralarının kutu içinde ortalı görünmesi, kullanıcı deneyimi açısından standarttır.
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;

            // Kredi kartı numarası maskeleme kuralı (Örn: 1234-5678-9012-3456)
            Properties.Mask.MaskType = MaskType.Regular;
            Properties.Mask.EditMask = @"\d?\d?\d?\d?-\d?\d?\d?\d?-\d?\d?\d?\d?-\d?\d?\d?\d?";
            Properties.Mask.AutoComplete = AutoCompleteType.None;

            // Durum çubuğu (StatusBar) bilgi mesajı
            StatusBarAciklama = "Kart Numarasını Giriniz.";
        }
    }
}
