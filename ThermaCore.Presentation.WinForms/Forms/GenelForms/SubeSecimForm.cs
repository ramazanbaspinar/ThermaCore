using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ThermaCore.Application.DTOs.Management;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;

namespace ThermaCore.Presentation.WinForms.Forms.GenelForms
{
    public partial class SubeSecimForm : XtraForm
    {
        public long SeciliSubeId { get; private set; }
        public string SeciliSubeAdi { get; private set; } = string.Empty;
        public bool SecimiHatirla => myCheckEdit1.Checked;

        private readonly List<BranchDto> _branches;

        public SubeSecimForm(List<BranchDto> branches)
        {
            InitializeComponent();
            _branches = branches;
            myGridControl1.DataSource = _branches;

            btnSecVeBasla.Click += BtnSecVeBasla_Click;
            btnIptalCikis.Click += BtnIptalCikis_Click;
            myGridView1.DoubleClick += MyGridView1_DoubleClick;
            this.FormClosing += SubeSecimForm_FormClosing;
        }

        private void MyGridView1_DoubleClick(object? sender, System.EventArgs e)
        {
            SecimiYap();
        }

        private void BtnSecVeBasla_Click(object? sender, System.EventArgs e)
        {
            SecimiYap();
        }

        private void SecimiYap()
        {
            var rowHandle = myGridView1.FocusedRowHandle;
            if (rowHandle >= 0)
            {
                var row = myGridView1.GetRow(rowHandle) as BranchDto;
                if (row != null)
                {
                    SeciliSubeId = row.Id;
                    SeciliSubeAdi = row.BranchName;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void BtnIptalCikis_Click(object? sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SubeSecimForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK && this.DialogResult != DialogResult.Cancel)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}