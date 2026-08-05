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
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MatbaaKilavuzForms
{
    public partial class MatbaaKilavuzListForm : BaseListForm
    {
        private readonly WinBeyazEsya.Application.Interfaces.Definitions.IManualService _manualService;

        public MatbaaKilavuzListForm()
        {
            InitializeComponent();
            _manualService = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<WinBeyazEsya.Application.Interfaces.Definitions.IManualService>(Program.ServiceProvider);
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.MatbaaTanimlari;
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

            if (WinBeyazEsya.Presentation.WinForms.Helpers.Messages.SilMesaj(Tablo.GetFocusedRowCellValue("Code")?.ToString() ?? "") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _manualService.Delete(entityId);
                    Listele();
                    WinBeyazEsya.Presentation.WinForms.Helpers.Messages.SilindiMesaj();
                }
                catch (Exception ex)
                {
                    WinBeyazEsya.Presentation.WinForms.Helpers.Messages.HataBasligi(ex.Message, "Silme Hatası");
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }
    }
}
