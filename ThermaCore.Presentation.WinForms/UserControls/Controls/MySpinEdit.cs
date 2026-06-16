#pragma warning disable CS8618
using DevExpress.Utils;
using DevExpress.XtraEditors;
using ThermaCore.Presentation.WinForms.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace ThermaCore.Presentation.WinForms.UserControls
{
    [ToolboxItem(true)]
    public class MySpinEdit : SpinEdit, IStatusBarAciklama
    {
        public MySpinEdit()
        {
            Properties.Appearance.Font = new Font("Segoe UI", 9f);
            Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9f);
            Properties.AppearanceDropDown.Font = new Font("Segoe UI", 9f);
            Properties.AppearanceFocused.Font = new Font("Segoe UI", 9f);
            Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9f);

            Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            Properties.AllowNullInput = DefaultBoolean.False;
            Properties.EditMask = "n0";
        }
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarAciklama { get; set; }
    }
}

