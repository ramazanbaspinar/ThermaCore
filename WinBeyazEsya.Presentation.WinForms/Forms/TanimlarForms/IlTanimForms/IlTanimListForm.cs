using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.IlTanimForms
{
    public partial class IlTanimListForm : BaseListForm
    {
        private readonly ICityService _cityService = default!;
        private readonly IServiceProvider _serviceProvider = default!;
        private long _countryId = 0;
        private string _countryName = "";

        public IlTanimListForm()
        {
            InitializeComponent();
        }

        public IlTanimListForm(ICityService cityService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            if (!DesignMode && Program.ServiceProvider != null)
            {
                _cityService = cityService;
                _serviceProvider = serviceProvider;
                Bll = _cityService;
            }
            Tablo = myGridView1;
            ShowItems = new DevExpress.XtraBars.BarItem[] { btnYeni, btnSil, btnYenile, btnBagliKayitlar };
        }

        public void SetUlke(long countryId, string countryName)
        {
            _countryId = countryId;
            _countryName = countryName;
            this.Text = $"{_countryName} - İller";
            HideItems = new DevExpress.XtraBars.BarItem[] { btnSec, btnFavorilereEkle };
            Listele();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = Domain.Enums.ModuleType.City;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
            FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Duzenleme;
            if (btnBagliKayitlar != null) btnBagliKayitlar.Caption = "İlçeler";
        }

        protected override void Listele()
        {
            var liste = _cityService.GetAll().Where(x => x.IsActive == AktifKartlariGoster);
            if (_countryId > 0)
            {
                liste = liste.Where(x => x.CountryId == _countryId);
            }
            Tablo.GridControl.DataSource = liste.ToList();
        }

        protected override void ShowEditForm(long id)
        {
            if (_serviceProvider != null)
            {
                var form = _serviceProvider.GetRequiredService<IlTanimEditForm>();
                if (form != null)
                {
                    form.SetUlke(_countryId);
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
                var form = _serviceProvider.GetRequiredService<IlceTanimForms.IlceTanimListForm>();
                form.SetIl(entityId, title);
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
                    _cityService.Delete(entityId);
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