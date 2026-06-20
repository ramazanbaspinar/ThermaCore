using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThermaCore.Application.Registries;
using ThermaCore.Domain.Enums;
using System.Text.Json;

namespace ThermaCore.Presentation.WinForms.Forms.YetkilendirmeForms
{
    public partial class OzelYetkiEditForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly ModuleType _module;
        private List<OzelYetkiRowDto> _rows = new();

        public string SpecialPermissionsJson { get; private set; }

        public OzelYetkiEditForm(ModuleType module, string currentJson)
        {
            InitializeComponent();
            _module = module;
            SpecialPermissionsJson = currentJson ?? string.Empty;

            this.Load += OzelYetkiEditForm_Load;
            btnTamam.Click += BtnTamam_Click;
            btnIptal.Click += BtnIptal_Click;
        }

        private void OzelYetkiEditForm_Load(object? sender, EventArgs e)
        {
            var registryList = SpecialPermissionRegistry.GetPermissions(_module);
            
            Dictionary<string, bool> parsedDict = new();
            if (!string.IsNullOrWhiteSpace(SpecialPermissionsJson))
            {
                try
                {
                    parsedDict = JsonSerializer.Deserialize<Dictionary<string, bool>>(SpecialPermissionsJson) ?? new();
                }
                catch
                {
                    // JSON parse error, ignore and use empty
                }
            }

            foreach (var def in registryList)
            {
                bool isChecked = parsedDict.TryGetValue(def.Key, out bool val) && val;
                
                _rows.Add(new OzelYetkiRowDto
                {
                    Key = def.Key,
                    YetkiAciklamasi = def.Description,
                    Secim = isChecked
                });
            }

            myGridControl1.DataSource = _rows;
        }

        private void BtnTamam_Click(object? sender, EventArgs e)
        {
            myGridView1.PostEditor(); // Ensure current edits are committed

            var dict = new Dictionary<string, bool>();
            foreach (var row in _rows)
            {
                // Only save true values to keep JSON small, or save all. Saving all is fine.
                if (row.Secim)
                {
                    dict[row.Key] = true;
                }
            }

            if (dict.Count > 0)
            {
                SpecialPermissionsJson = JsonSerializer.Serialize(dict);
            }
            else
            {
                SpecialPermissionsJson = string.Empty;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnIptal_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    public class OzelYetkiRowDto
    {
        public string Key { get; set; } = string.Empty;
        public string YetkiAciklamasi { get; set; } = string.Empty;
        public bool Secim { get; set; }
    }
}