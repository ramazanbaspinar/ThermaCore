using System;
using System.Windows.Forms;
// DevExpress kurulumu sonrasında aktif edilecek
// using DevExpress.XtraBars.Ribbon;
// using DevExpress.XtraGrid;

namespace ThermaCore.Presentation.WinForms.Forms.BaseForms;

// public partial class BaseListForm : RibbonForm
public partial class BaseListForm : Form
{
    public BaseListForm()
    {
        this.FormClosing += BaseListForm_FormClosing;
        this.Load += BaseListForm_Load;
    }

    private void BaseListForm_Load(object? sender, EventArgs e)
    {
        // LayoutHelper entegrasyonu (Grid düzenleri)
        // UIHelper.RestoreGridLayout(this.Name, gridView1);
    }

    private void BaseListForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        // Grid ve form yerleşim kayıt işlemi
        // UIHelper.SaveGridLayout(this.Name, gridView1);
    }
}
