using DevExpress.XtraEditors.Mask;
using System.ComponentModel;
using ThermaCore.Presentation.WinForms.Interfaces;

namespace ThermaCore.Presentation.WinForms.UserControls
{
    [ToolboxItem(true)]
    public class MyEmailTextEditPro : MyTextEditPro // Projenin genel uyumu için miras alınan sınıfı da 'Pro' olarak güncellemeyi unutma.
    {
        public MyEmailTextEditPro()
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