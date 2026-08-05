using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.PleytForms
{
    public partial class PleytListForm : BaseListForm
    {
        private readonly IHotplateService _hotplateService = default!;

        public PleytListForm()
        {
            InitializeComponent();
        }

        public PleytListForm(IHotplateService hotplateService)
        {
            InitializeComponent();
            _hotplateService = hotplateService;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = ModuleType.PleytIsiticiTanimlari;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
        }

        protected override void Listele()
        {
            var list = _hotplateService.GetAllList().Where(x => x.IsActive == AktifKartlariGoster).ToList();
            myGridControl1.DataSource = list;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<PleytEditForm>();
            form.BaseIslemTuru = id <= 0 ? ActionType.EntityInsert : ActionType.EntityUpdate;
            form.Id = id;
            form.ShowDialog();

            if (form.RefreshYapilacak)
                Listele();
        }
        
        protected override void EntityDelete()
        {
            if (Tablo.FocusedRowHandle < 0) return;

            if (Messages.SilMesaj("Pleyt Isıtıcı Tanımı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var id = (long)Tablo.GetFocusedRowCellValue("Id");
                    _hotplateService.Delete(id);
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
