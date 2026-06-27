using DevExpress.XtraEditors.Mask;
using System.ComponentModel;

namespace ThermaCore.Presentation.WinForms.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyTcKimlikNoTextEditPro : MyTextEditPro // Standartlaştırdığımız ana sınıftan miras alıyor
    {
        public MyTcKimlikNoTextEditPro()
        {
            // --- İŞLEVSEL AYARLAR ---

            // Türkiye standartlarındaki 11 haneli TC Kimlik Numarası formatını zorunlu kılar.
            // E-Fatura, İK ve Cari/Şahıs kartları modüllerinde hatalı veya eksik veri girişini engeller.
            Properties.Mask.MaskType = MaskType.Regular;
            Properties.Mask.EditMask = @"\d?\d?\d? \d?\d?\d? \d?\d?\d? \d?\d?";
            Properties.Mask.AutoComplete = AutoCompleteType.None;

            // Durum çubuğu (StatusBar) bilgi mesajı
            StatusBarAciklama = "Tc Kimlik No Giriniz.";
        }
    }
}