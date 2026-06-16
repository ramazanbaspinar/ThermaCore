#pragma warning disable CS8618
using DevExpress.XtraEditors;
using ThermaCore.Presentation.WinForms.Interfaces;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ThermaCore.Presentation.WinForms.UserControls.Controls
{
    public class MyHyperlinkLabelControl : HyperlinkLabelControl, IStatusBarAciklama
    {
        [ToolboxItem(true)]
        public MyHyperlinkLabelControl()
        {
            Cursor = Cursors.Hand;
            LinkBehavior = LinkBehavior.NeverUnderline;
            Font = new Font("Segoe UI", 9f);
        }

        public string StatusBarAciklama { get; set; }
    }
}

