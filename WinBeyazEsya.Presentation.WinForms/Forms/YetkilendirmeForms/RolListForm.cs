using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBeyazEsya.Application.Interfaces.Security;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;

namespace WinBeyazEsya.Presentation.WinForms.Forms.YetkilendirmeForms
{
    public partial class RolListForm : BaseListForm
    {
        private readonly IRoleService _roleService;

        public RolListForm()
        {
            InitializeComponent();
            _roleService = Program.ServiceProvider.GetService<IRoleService>()!;
            Bll = _roleService;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = Domain.Enums.ModuleType.YetkiGruplari;
            FormShow = new RolEditForm();
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = _roleService.GetAll().Where(x => x.IsActive == AktifKartlariGoster).ToList();
        }

        protected override void ShowEditForm(long id)
        {
            using (var frm = new RolEditForm())
            {
                frm.IdAtaVeAc(id);
                if (frm.RefreshYapilacak)
                {
                    Listele();
                }
            }
        }

        protected override void EntityDelete()
        {
            if (Tablo.FocusedRowHandle < 0) return;
            long id = 0;
            long.TryParse(Tablo.GetFocusedRowCellValue("Id")?.ToString(), out id);
            
            if (id > 0 && WinBeyazEsya.Presentation.WinForms.Helpers.Messages.SilMesaj("Rol") == DialogResult.Yes)
            {
                _roleService.Delete(id);
                Listele();
            }
        }
    }
}
