#pragma warning disable CS8618
using DevExpress.Utils;
using System.ComponentModel;
using System.Drawing;

namespace ThermaCore.Presentation.WinForms.UserControls
{
    [ToolboxItem(true)]
    public class MyKodTextEdit : MyTextEdit
    {
        public MyKodTextEdit()
        {
            Properties.Appearance.BackColor = Color.FromArgb(220, 235, 250);
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            StatusBarAciklama = "Kod Giriniz.";
        }
    }
}

