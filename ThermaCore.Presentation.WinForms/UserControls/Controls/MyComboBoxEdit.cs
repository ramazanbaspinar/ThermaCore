#pragma warning disable CS8618
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ThermaCore.Presentation.WinForms.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace ThermaCore.Presentation.WinForms.UserControls
{
    [ToolboxItem(true)]
    public class MyComboBoxEdit : ComboBoxEdit, IStatusBarKisaYol
    {
        public MyComboBoxEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            Properties.Appearance.Font = new Font("Segoe UI", 9f);
            Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9f);
            Properties.AppearanceItemDisabled.Font = new Font("Segoe UI", 9f);
            Properties.AppearanceDropDown.Font = new Font("Segoe UI", 9f);
            Properties.AppearanceItemSelected.Font = new Font("Segoe UI", 9f);
            Properties.AppearanceItemHighlight.Font = new Font("Segoe UI", 9f);
            Properties.AppearanceDropDown.Font = new Font("Segoe UI", 9f);
            Properties.AppearanceFocused.Font = new Font("Segoe UI", 9f);
            Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9f);
        }
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }
    }
}

