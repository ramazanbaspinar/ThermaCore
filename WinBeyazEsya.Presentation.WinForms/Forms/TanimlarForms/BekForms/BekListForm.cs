using DevExpress.XtraBars;
using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using System.Linq;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.BekForms
{
    public partial class BekListForm : BaseListForm
    {
        private readonly IBurnerService _burnerService;
        private readonly System.IServiceProvider _serviceProvider;

        public BekListForm(IBurnerService burnerService, System.IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _burnerService = burnerService;
            _serviceProvider = serviceProvider;

            Bll = _burnerService;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = Domain.Enums.ModuleType.BekGrubuTanimlari;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
        }

        protected override void Listele()
        {
            var liste = _burnerService.GetAll().Where(x => x.IsActive == AktifKartlariGoster).ToList();
            Tablo.GridControl.DataSource = liste;
        }

        protected override void ShowEditForm(long id)
        {
            var form = _serviceProvider.GetRequiredService<BekEditForm>();
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

            var result = WinBeyazEsya.Presentation.WinForms.Helpers.Messages.SilMesaj(Tablo.GetRowCellValue(Tablo.FocusedRowHandle, "Name")?.ToString() ?? "");
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    _burnerService.Delete(entityId);
                    Listele();
                }
                catch (System.Exception ex)
                {
                    WinBeyazEsya.Presentation.WinForms.Helpers.Messages.HataBasligi(ex.Message, "Silme Hatası");
                }
            }
        }
    }
}
