using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinBeyazEsya.Application.DTOs.Management;
using DevExpress.XtraEditors;

namespace WinBeyazEsya.Presentation.WinForms.Forms.GenelForms
{
    public partial class SubeSecimForm : XtraForm
    {
        public long SeciliSubeId { get; private set; }
        public string SeciliSubeAdi { get; private set; } = string.Empty;
        public bool VarsayilanYap => chkVarsayilanYap.Checked;
        public bool AcilistaSor => chkAcilistaSor.Checked;

        private readonly List<BranchDto> _branches;

        public SubeSecimForm(List<BranchDto> branches, long lastBranchId = 0, bool askAtStartup = true)
        {
            InitializeComponent();
            _branches = branches;
            
            chkVarsayilanYap.Checked = lastBranchId > 0;
            chkAcilistaSor.Checked = askAtStartup;
            
            foreach (var branch in _branches)
            {
                cmbSubeler.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(branch.BranchName, branch.Id, -1));
            }
            
            if (cmbSubeler.Properties.Items.Count > 0)
            {
                if (lastBranchId > 0 && _branches.Any(b => b.Id == lastBranchId))
                {
                    cmbSubeler.EditValue = lastBranchId;
                }
                else
                {
                    cmbSubeler.SelectedIndex = 0;
                }
            }

            btnSecVeBasla.Click += BtnSecVeBasla_Click;
            btnIptalCikis.Click += BtnIptalCikis_Click;
            this.FormClosing += SubeSecimForm_FormClosing;
        }

        private void BtnSecVeBasla_Click(object? sender, EventArgs e)
        {
            if (cmbSubeler.EditValue == null)
            {
                XtraMessageBox.Show("Lütfen giriş yapmak için bir şube/fabrika seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long selectedId = (long)cmbSubeler.EditValue;
            var selectedBranch = _branches.FirstOrDefault(x => x.Id == selectedId);
            
            if (selectedBranch != null)
            {
                SeciliSubeId = selectedBranch.Id;
                SeciliSubeAdi = selectedBranch.BranchName;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnIptalCikis_Click(object? sender, EventArgs e)
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

