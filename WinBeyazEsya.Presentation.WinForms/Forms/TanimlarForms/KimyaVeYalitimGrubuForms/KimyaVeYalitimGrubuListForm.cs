using System.Data;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.KimyaVeYalitimGrubuForms
{
    public partial class KimyaVeYalitimGrubuListForm : BaseListForm
    {
        private readonly WinBeyazEsya.Application.Interfaces.Definitions.IChemicalAndInsulationGroupService _chemicalAndInsulationGroupService = default!;
        private readonly IServiceProvider _serviceProvider = default!;

        public KimyaVeYalitimGrubuListForm()
        {
            InitializeComponent();
        }

        public KimyaVeYalitimGrubuListForm(
            WinBeyazEsya.Application.Interfaces.Definitions.IChemicalAndInsulationGroupService chemicalAndInsulationGroupService,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();

            if (!DesignMode && Program.ServiceProvider != null)
            {
                _chemicalAndInsulationGroupService = chemicalAndInsulationGroupService;
                _serviceProvider = serviceProvider;
                Bll = _chemicalAndInsulationGroupService;
            }

            ShowItems = new DevExpress.XtraBars.BarItem[] { btnYeni, btnSil, btnYenile };
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = Domain.Enums.ModuleType.KimyaVeYalitimGrubu;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
        }

        protected override void Listele()
        {
            var liste = _chemicalAndInsulationGroupService.GetAll().Where(x => x.IsActive == AktifKartlariGoster);

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
                var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<KimyaVeYalitimGrubuEditForm>(_serviceProvider);
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

            var result = Helpers.Messages.SilMesaj(Tablo.GetRowCellValue(Tablo.FocusedRowHandle, "Name")?.ToString() ?? "");
            if (result == DialogResult.Yes)
            {
                try
                {
                    _chemicalAndInsulationGroupService.Delete(entityId);
                    Listele();
                }
                catch (Exception ex)
                {
                    Helpers.Messages.HataBasligi(ex.Message, "Silme Hatası");
                }
            }
        }
    }
}