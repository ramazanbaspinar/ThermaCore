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

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.CamForms
{
    public partial class CamListForm : BaseListForm
    {
        private readonly IOvenGlassService _ovenGlassService = default!;

        public CamListForm()
        {
            InitializeComponent();
        }

        public CamListForm(IOvenGlassService ovenGlassService)
        {
            InitializeComponent();
            _ovenGlassService = ovenGlassService;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = ModuleType.CamTanimlari;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
        }

        protected override void Listele()
        {
            var list = _ovenGlassService.GetAll().Where(x => x.IsActive == AktifKartlariGoster).ToList();
            myGridControl1.DataSource = list;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<CamEditForm>();
            form.BaseIslemTuru = id <= 0 ? ActionType.EntityInsert : ActionType.EntityUpdate;
            form.Id = id;
            form.ShowDialog();

            if (form.RefreshYapilacak)
                Listele();
        }

        protected override void EntityDelete()
        {
            if (Tablo.FocusedRowHandle < 0) return;

            if (Messages.SilMesaj("Cam Tanımı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var id = (long)Tablo.GetFocusedRowCellValue("Id");
                    _ovenGlassService.Delete(id);
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
