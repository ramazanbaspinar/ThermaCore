using DevExpress.XtraEditors.Mask;
using System.ComponentModel;
using WinBeyazEsya.Presentation.WinForms.Interfaces;

namespace WinBeyazEsya.Presentation.WinForms.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyEmailTextEdit : MyTextEdit // Projenin genel uyumu için miras alınan sınıfı da 'Pro' olarak güncellemeyi unutma.
    {
        public MyEmailTextEdit()
        {
            // --- İŞLEVSEL AYARLAR ---

            // Kullanıcının geçersiz bir e-posta formatı girmesini engeller (Örn: '@' veya '.' eksiklikleri).
            // ERP sistemlerinde cari veya personel kartlarındaki iletişim verilerinin tutarlılığı için zorunludur.
            Properties.Mask.MaskType = MaskType.RegEx;
            Properties.Mask.EditMask = @"((([0-9a-zA-Z_%-])+[.])+|([0-9a-zA-Z_%-])+)+@((([0-9a-zA-Z_-])+[.])+|([0-9a-zA-Z_-])+)+";
            Properties.Mask.AutoComplete = AutoCompleteType.Strong;

            // Durum çubuğu (StatusBar) bilgi mesajı
            StatusBarAciklama = "E-Posta Adresi Giriniz.";
        }
    }
}
