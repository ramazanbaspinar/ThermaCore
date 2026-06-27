using DevExpress.XtraEditors.Mask;
using System.ComponentModel;

namespace ThermaCore.Presentation.WinForms.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyTelefonNoTextEditPro : MyTextEditPro // Standartlaştırdığımız ana sınıftan miras alıyor
    {
        public MyTelefonNoTextEditPro()
        {
            // --- İŞLEVSEL AYARLAR ---

            // Telefon numaralarının standart bir yapıda (Örn: (5xx) xxx xx xx) girilmesini zorunlu kılar.
            // Veri tutarlılığını artırır ve ileride eklenebilecek SMS/Bildirim entegrasyonlarında hata riskini sıfırlar.
            Properties.Mask.MaskType = MaskType.Regular;
            Properties.Mask.EditMask = @"(\d?\d?\d?) \d?\d?\d? \d?\d? \d?\d?";
            Properties.Mask.AutoComplete = AutoCompleteType.None;

            // Durum çubuğu (StatusBar) bilgi mesajı
            StatusBarAciklama = "Telefon Numarası Giriniz.";
        }
    }
}