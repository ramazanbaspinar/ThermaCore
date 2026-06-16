#pragma warning disable CS8618
using ThermaCore.Presentation.WinForms.Interfaces;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ThermaCore.Presentation.WinForms.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyComboBox : ComboBox, IStatusBarAciklama
    {
        public MyComboBox()
        {
            Font = new Font("Segoe UI", 9f);

            AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        public string StatusBarAciklama { get; set; }
    }
}

