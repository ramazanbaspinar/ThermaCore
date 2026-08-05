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
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Functions;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.KaliteStandartForms
{
    public partial class KaliteStandartListForm : BaseListForm
    {
        private readonly IQualityStandardService _service;

        public KaliteStandartListForm(IQualityStandardService service)
        {
            InitializeComponent();
            _service = service;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = ModuleType.KaliteStandartTanimlari;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
        }

        protected override void Listele()
        {
            var entities = _service.GetAll().Where(x => x.IsActive == AktifKartlariGoster).ToList();
            Tablo.GridControl.DataSource = entities;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<KaliteStandartEditForm>(Program.ServiceProvider);
            if (form != null)
            {
                form.IdAtaVeAc(id);
                Listele();
                if (form.Id > 0)
                {
                    Tablo.RowFocus("Id", form.Id);
                }
            }
        }

        protected override void EntityDelete()
        {
            if (Tablo.FocusedRowHandle < 0) return;

            long entityId = 0;
            long.TryParse(Tablo.GetFocusedRowCellValue("Id")?.ToString(), out entityId);
            
            if (entityId <= 0) return;

            if (DevExpress.XtraEditors.XtraMessageBox.Show("Seçili kaydı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _service.Delete(entityId);
                Tablo.DeleteSelectedRows();
                Tablo.RowFocus("Id", Tablo.FocusedRowHandle);
            }
        }
    }
}
