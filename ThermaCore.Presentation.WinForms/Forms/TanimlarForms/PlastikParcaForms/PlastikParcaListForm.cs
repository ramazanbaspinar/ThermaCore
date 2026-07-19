using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;
using ThermaCore.Application.Interfaces.Definitions;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.PlastikParcaForms
{
    public partial class PlastikParcaListForm : BaseListForm
    {
        private readonly IPlasticPartService _service = default!;

        public PlastikParcaListForm()
        {
            InitializeComponent();
            
            if (!DesignMode && Program.ServiceProvider != null)
            {
                _service = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<IPlasticPartService>(Program.ServiceProvider);
                BaseKartTuru = ModuleType.PlastikParcaTanimlari;
            }
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = ModuleType.PlastikParcaTanimlari;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
        }

        protected override void Listele()
        {
            if (_service == null) return;
            var liste = _service.GetAll().Where(x => x.IsActive == AktifKartlariGoster).ToList();
            Tablo.GridControl.DataSource = liste;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<PlastikParcaEditForm>();
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

            var result = Messages.SilMesaj(Tablo.GetRowCellValue(Tablo.FocusedRowHandle, "Name")?.ToString() ?? "");
            if (result == DialogResult.Yes)
            {
                try
                {
                    _service.Delete(entityId);
                    Listele();
                }
                catch (Exception ex)
                {
                    Messages.HataBasligi(ex.Message, "Silme Hatası");
                }
            }
        }
    }
}