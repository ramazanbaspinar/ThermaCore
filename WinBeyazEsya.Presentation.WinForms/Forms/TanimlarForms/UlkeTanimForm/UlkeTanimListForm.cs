using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.UlkeTanimForm
{
    public partial class UlkeTanimListForm : BaseListForm
    {
        private readonly ICountryService _countryService = default!;
        private readonly IServiceProvider _serviceProvider = default!;

        public UlkeTanimListForm()
        {
            InitializeComponent();
        }

        public UlkeTanimListForm(ICountryService countryService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            if (!DesignMode && Program.ServiceProvider != null)
            {
                _countryService = countryService;
                _serviceProvider = serviceProvider;
                Bll = _countryService;
            }
            Tablo = myGridView1;
            btnBagliKayitlar.Caption = "İller";
            ShowItems = new DevExpress.XtraBars.BarItem[] { btnYeni, btnSil, btnYenile, btnBagliKayitlar };
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = Domain.Enums.ModuleType.Country;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
        }

        protected override void Listele()
        {
            var liste = _countryService.GetAll().Where(x => x.IsActive == AktifKartlariGoster);
            Tablo.GridControl.DataSource = liste.ToList();
        }

        protected override void ShowEditForm(long id)
        {
            if (_serviceProvider != null)
            {
                var form = _serviceProvider.GetRequiredService<UlkeTanimEditForm>();
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

        protected override void BagliKayitAc()
        {
            if (Tablo.FocusedRowHandle < 0) return;

            long entityId = 0;
            long.TryParse(Tablo.GetFocusedRowCellValue("Id")?.ToString(), out entityId);
            string title = Tablo.GetFocusedRowCellValue("Title")?.ToString() ?? "";

            if (entityId <= 0) return;

            if (_serviceProvider != null)
            {
                var form = _serviceProvider.GetRequiredService<IlTanimForms.IlTanimListForm>();
                form.SetUlke(entityId, title);
                form.ShowDialog();
            }
        }

        protected override void EntityDelete()
        {
            if (Tablo.FocusedRowHandle < 0) return;

            long entityId = 0;
            long.TryParse(Tablo.GetFocusedRowCellValue("Id")?.ToString(), out entityId);

            if (entityId <= 0) return;

            if (Helpers.Messages.SilMesaj(Tablo.GetRowCellValue(Tablo.FocusedRowHandle, "Title")?.ToString() ?? "") == DialogResult.Yes)
            {
                try
                {
                    _countryService.Delete(entityId);
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