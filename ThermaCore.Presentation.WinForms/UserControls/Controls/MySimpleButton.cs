#pragma warning disable CS8618
using DevExpress.XtraEditors;
using ThermaCore.Presentation.WinForms.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace ThermaCore.Presentation.WinForms.UserControls
{
    [ToolboxItem(true)]
    public class MySimpleButton : SimpleButton, IStatusBarAciklama
    {
        public MySimpleButton()
        {
            Appearance.Font = new Font("Segoe UI", 9f);
            AppearanceDisabled.Font = new Font("Segoe UI", 9f);
            AppearanceHovered.Font = new Font("Segoe UI", 9f);
            AppearancePressed.Font = new Font("Segoe UI", 9f);
        }
        public string StatusBarAciklama { get; set; }
    }
}

