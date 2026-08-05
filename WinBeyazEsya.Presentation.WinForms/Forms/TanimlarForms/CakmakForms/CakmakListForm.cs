using System.Linq;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.CakmakForms
{
    public partial class CakmakListForm : BaseListForm
    {
        private readonly ISparkPlugService _sparkPlugService = default!;

        public CakmakListForm()
        {
            InitializeComponent();
            
            if (!DesignMode && Program.ServiceProvider != null)
            {
                _sparkPlugService = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetService<ISparkPlugService>(Program.ServiceProvider);
                BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.CakmakTanimlari;
            }
        }

        public CakmakListForm(ISparkPlugService sparkPlugService)
        {
            InitializeComponent();
            _sparkPlugService = sparkPlugService;
            
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.CakmakTanimlari;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.CakmakTanimlari;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
            
            colCakmakAdi.FieldName = "Name";
            colUzunluk.FieldName = "LengthMm";
            colBaglantiTipi.FieldName = "ConnectionType";
            colUcTipi.FieldName = "SparkTipType";
        }

        protected override void Listele()
        {
            var liste = _sparkPlugService.GetAll().Where(x => x.IsActive == AktifKartlariGoster).ToList();
            Tablo.GridControl.DataSource = liste;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetService<CakmakEditForm>(Program.ServiceProvider);
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
                    _sparkPlugService.Delete(entityId);
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
