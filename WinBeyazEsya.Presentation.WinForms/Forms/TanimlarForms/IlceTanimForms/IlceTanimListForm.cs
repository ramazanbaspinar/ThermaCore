using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.IlceTanimForms
{
    public partial class IlceTanimListForm : BaseListForm
    {
        private readonly ITownService _townService = default!;
        private readonly IServiceProvider _serviceProvider = default!;
        private long _cityId = 0;
        private string _cityName = "";

        public IlceTanimListForm()
        {
            InitializeComponent();
        }

        public IlceTanimListForm(ITownService townService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            if (!DesignMode && Program.ServiceProvider != null)
            {
                _townService = townService;
                _serviceProvider = serviceProvider;
                Bll = _townService;
            }
            Tablo = myGridView1;
            ShowItems = new DevExpress.XtraBars.BarItem[] { btnYeni, btnSil, btnYenile };
        }

        public void SetIl(long cityId, string cityName)
        {
            _cityId = cityId;
            _cityName = cityName;
            this.Text = $"{_cityName} - İlçeler";
            HideItems = new DevExpress.XtraBars.BarItem[] { btnSec, btnFavorilereEkle };
            Listele();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = Domain.Enums.ModuleType.Town;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
            FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Duzenleme;
        }

        protected override void Listele()
        {
            var liste = _townService.GetAll().Where(x => x.IsActive == AktifKartlariGoster);
            if (_cityId > 0)
            {
                liste = liste.Where(x => x.CityId == _cityId);
            }
            Tablo.GridControl.DataSource = liste.ToList();
        }

        protected override void ShowEditForm(long id)
        {
            if (_serviceProvider != null)
            {
                var form = _serviceProvider.GetRequiredService<IlceTanimEditForm>();
                if (form != null)
                {
                    form.SetIl(_cityId);
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

            if (Helpers.Messages.SilMesaj(Tablo.GetRowCellValue(Tablo.FocusedRowHandle, "Title")?.ToString() ?? "") == DialogResult.Yes)
            {
                try
                {
                    _townService.Delete(entityId);
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