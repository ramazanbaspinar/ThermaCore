#pragma warning disable CS8618
using DevExpress.XtraEditors;
using ThermaCore.Presentation.WinForms.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace ThermaCore.Presentation.WinForms.UserControls
{
    [ToolboxItem(true)]
    public class MyFilterControl : FilterControl, IStatusBarAciklama
    {
        public MyFilterControl()
        {
            Font = new Font("Segoe UI", 9f);
            ShowGroupCommandsIcon = true;
        }
        public string StatusBarAciklama { get; set; } = "Filtre Metni Giriniz.";
    }
}

