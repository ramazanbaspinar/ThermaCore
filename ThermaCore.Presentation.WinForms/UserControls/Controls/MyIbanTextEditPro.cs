using DevExpress.XtraEditors.Mask;
using System.ComponentModel;

namespace ThermaCore.Presentation.WinForms.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyIbanTextEditPro : MyTextEditPro // Önceki adımda standartlaştırdığımız ana sınıftan miras alıyor
    {
        public MyIbanTextEditPro()
        {
            // --- İŞLEVSEL AYARLAR ---

            // Türkiye standartlarındaki IBAN formatını (TR ve ardından 4'erli gruplar) zorunlu kılar.
            // Kullanıcının eksik veya fazla hane girmesini engelleyerek finansal veri bütünlüğünü korur.
            Properties.Mask.MaskType = MaskType.Regular;
            Properties.Mask.EditMask = @"TR\d?\d? \d?\d?\d?\d? \d?\d?\d?\d? \d?\d?\d?\d? \d?\d?\d?\d? \d?\d?\d?\d? \d?\d?";
            Properties.Mask.AutoComplete = AutoCompleteType.None;

            // Durum çubuğu (StatusBar) bilgi mesajı
            StatusBarAciklama = "Iban Numarasını Giriniz.";
        }
    }
}