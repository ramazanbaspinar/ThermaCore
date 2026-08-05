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

namespace WinBeyazEsya.Presentation.WinForms.Forms.VidaForms
{
    public partial class VidaListForm : BaseListForm
    {
        private readonly IScrewService _screwService = default!;

        public VidaListForm()
        {
            InitializeComponent();
        }

        public VidaListForm(IScrewService screwService)
        {
            InitializeComponent();
            _screwService = screwService;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = ModuleType.VidaTanimlari;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
        }

        protected override void Listele()
        {
            var list = _screwService.GetAll().Where(x => x.IsActive == AktifKartlariGoster).ToList();
            myGridControl1.DataSource = list;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<VidaEditForm>();
            form.BaseIslemTuru = id <= 0 ? ActionType.EntityInsert : ActionType.EntityUpdate;
            form.Id = id;
            form.ShowDialog();
            
            if (form.RefreshYapilacak)
                Listele();
        }

        protected override void EntityDelete()
        {
            if (Tablo.FocusedRowHandle < 0) return;

            if (Messages.SilMesaj("Vida Tanımı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var id = (long)Tablo.GetFocusedRowCellValue("Id");
                    _screwService.Delete(id);
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
