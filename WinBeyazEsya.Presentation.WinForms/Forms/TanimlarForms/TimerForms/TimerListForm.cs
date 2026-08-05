using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.TimerForms
{
    public partial class TimerListForm : BaseListForm
    {
        private readonly IOvenTimerService _ovenTimerService = default!;

        public TimerListForm()
        {
            InitializeComponent();
        }

        public TimerListForm(IOvenTimerService ovenTimerService)
        {
            InitializeComponent();
            _ovenTimerService = ovenTimerService;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = ModuleType.TimerTanimlari;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
        }

        protected override void Listele()
        {
            var list = _ovenTimerService.GetAll().Where(x => x.IsActive == AktifKartlariGoster).ToList();
            myGridControl1.DataSource = list;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<TimerEditForm>();
            form.BaseIslemTuru = id <= 0 ? ActionType.EntityInsert : ActionType.EntityUpdate;
            form.Id = id;
            form.ShowDialog();

            if (form.RefreshYapilacak)
                Listele();
        }

        protected override void EntityDelete()
        {
            if (Tablo.FocusedRowHandle < 0) return;

            if (Messages.SilMesaj("Timer Tanımı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var id = (long)Tablo.GetFocusedRowCellValue("Id");
                    _ovenTimerService.Delete(id);
                    Listele();
                    Messages.SilindiMesaj();
                }
                catch (Exception ex)
                {
                    Messages.HataBasligi(ex.Message, "Silme Hatası");
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }
    }
}
