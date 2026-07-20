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
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.MatbaaKilavuzForms
{
    public partial class MatbaaKilavuzListForm : BaseListForm
    {
        private readonly ThermaCore.Application.Interfaces.Definitions.IManualService _manualService;

        public MatbaaKilavuzListForm()
        {
            InitializeComponent();
            _manualService = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ThermaCore.Application.Interfaces.Definitions.IManualService>(Program.ServiceProvider);
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = ThermaCore.Domain.Enums.ModuleType.MatbaaTanimlari;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = _manualService.GetAll().Where(x => x.IsActive == AktifKartlariGoster).ToList();
        }

        protected override void ShowEditForm(long id)
        {
            var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<MatbaaKilavuzEditForm>(Program.ServiceProvider);
            form.IdAtaVeAc(id);
            Listele();
            if (form.Id > 0)
            {
                Tablo.RowFocus("Id", form.Id);
            }
        }

        protected override void EntityDelete()
        {
            if (Tablo.FocusedRowHandle < 0) return;

            long entityId = 0;
            long.TryParse(Tablo.GetFocusedRowCellValue("Id")?.ToString(), out entityId);
            
            if (entityId <= 0) return;

            if (ThermaCore.Presentation.WinForms.Helpers.Messages.SilMesaj(Tablo.GetFocusedRowCellValue("Code")?.ToString() ?? "") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _manualService.Delete(entityId);
                    Listele();
                    ThermaCore.Presentation.WinForms.Helpers.Messages.SilindiMesaj();
                }
                catch (Exception ex)
                {
                    ThermaCore.Presentation.WinForms.Helpers.Messages.HataBasligi(ex.Message, "Silme Hatası");
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }
    }
}