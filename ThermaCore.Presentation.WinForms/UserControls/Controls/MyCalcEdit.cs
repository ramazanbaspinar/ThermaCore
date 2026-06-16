#pragma warning disable CS8618
using DevExpress.Utils;
using DevExpress.XtraEditors;
using ThermaCore.Presentation.WinForms.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace ThermaCore.Presentation.WinForms.UserControls
{
    [ToolboxItem(true)]
    public class MyCalcEdit : CalcEdit, IStatusBarKisaYol
    {
        public MyCalcEdit()
        {
            Properties.Appearance.Font = new Font("Segoe UI", 9f);
            Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9f);
            Properties.AppearanceDropDown.Font = new Font("Segoe UI", 9f);
            Properties.AppearanceFocused.Font = new Font("Segoe UI", 9f);
            Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9f);

            Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            Properties.AllowNullInput = DefaultBoolean.False;
            Properties.DisplayFormat.FormatType = FormatType.Numeric;
            Properties.DisplayFormat.FormatString = "n2";
            Properties.EditFormat.FormatType = FormatType.Numeric;
            Properties.EditFormat.FormatString = "n2";
            Properties.EditMask = "n2";
            Properties.Mask.UseMaskAsDisplayFormat = true;
        }
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; } = "Hesap Makinesi";
        public string StatusBarAciklama { get; set; }
    }
}

