using System.Data;
using System.Linq;
using System.Windows.Forms;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.SatinAlmaForms
{
    public partial class SatinAlmaSiparisListForm : BaseListForm
    {
        private readonly WinBeyazEsya.Application.Interfaces.Purchasing.IPurchaseOrderService _purchaseOrderService = default!;
        private readonly System.IServiceProvider _serviceProvider = default!;

        public SatinAlmaSiparisListForm()
        {
            InitializeComponent();
        }

        public SatinAlmaSiparisListForm(
            WinBeyazEsya.Application.Interfaces.Purchasing.IPurchaseOrderService purchaseOrderService,
            System.IServiceProvider serviceProvider)
        {
            InitializeComponent();

            if (!DesignMode && Program.ServiceProvider != null)
            {
                _purchaseOrderService = purchaseOrderService;
                _serviceProvider = serviceProvider;
                Bll = _purchaseOrderService;
            }

            ShowItems = new DevExpress.XtraBars.BarItem[] { btnYeni, btnSil, btnYenile };
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = Domain.Enums.ModuleType.SatinalmaSiparisleri;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
        }

        protected override void Listele()
        {
            var liste = _purchaseOrderService.GetAll().Where(x => x.IsActive == AktifKartlariGoster);

            if (ListeDisiTutulacakKayitlar != null && ListeDisiTutulacakKayitlar.Any())
            {
                liste = liste.Where(x => !ListeDisiTutulacakKayitlar.Contains(x.Id));
            }

            Tablo.GridControl.DataSource = liste.ToList();
        }

        protected override void ShowEditForm(long id)
        {
            if (_serviceProvider != null)
            {
                var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<SatinAlmaSiparisEditForm>(_serviceProvider);
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
        }

        protected override void EntityDelete()
        {
            if (Tablo.FocusedRowHandle < 0) return;

            long entityId = 0;
            long.TryParse(Tablo.GetFocusedRowCellValue("Id")?.ToString(), out entityId);

            if (entityId <= 0) return;

            var result = Helpers.Messages.SilMesaj(Tablo.GetRowCellValue(Tablo.FocusedRowHandle, "DocumentNo")?.ToString() ?? Tablo.GetRowCellValue(Tablo.FocusedRowHandle, "Code")?.ToString() ?? "");
            if (result == DialogResult.Yes)
            {
                try
                {
                    _purchaseOrderService.Delete(entityId);
                    Listele();
                }
                catch (System.Exception ex)
                {
                    Helpers.Messages.HataBasligi(ex.Message, "Silme Hatası");
                }
            }
        }
    }
}