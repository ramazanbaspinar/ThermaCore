#pragma warning disable CS8618
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ThermaCore.Presentation.WinForms.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace ThermaCore.Presentation.WinForms.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyPictureEdit : PictureEdit, IStatusBarKisaYol
    {
        public MyPictureEdit()
        {
            Properties.Appearance.Font = new Font("Segoe UI", 9f);
            Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9f);
            Properties.AppearanceFocused.Font = new Font("Segoe UI", 9f);
            Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9f);

            Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            Properties.NullText = "Resim Yok";
            Properties.SizeMode = PictureSizeMode.Stretch;
            Properties.ShowMenu = false;
        }
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }
    }
}

