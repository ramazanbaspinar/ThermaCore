#pragma warning disable CS8618
using DevExpress.XtraEditors.Mask;
using System.ComponentModel;
namespace ThermaCore.Presentation.WinForms.UserControls
{
    [ToolboxItem(true)]
    public class MyTelefonNoTextEdit : MyTextEdit
    {
        public MyTelefonNoTextEdit()
        {
            Properties.Mask.MaskType = MaskType.Regular;
            Properties.Mask.EditMask = @"(\d?\d?\d?) \d?\d?\d? \d?\d? \d?\d?";
            Properties.Mask.AutoComplete = AutoCompleteType.None;
            StatusBarAciklama = "Telefon Numarası Giriniz.";
        }
    }
}

