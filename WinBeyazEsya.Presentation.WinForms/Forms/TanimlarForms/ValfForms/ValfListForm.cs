using System.Linq;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.ValfForms
{
    public partial class ValfListForm : BaseListForm
    {
        private readonly IValveService _valveService = default!;

        public ValfListForm()
        {
            InitializeComponent();
        }

        public ValfListForm(IValveService valveService)
        {
            InitializeComponent();
            _valveService = valveService;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.ValfTanimlari;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
            
            // Kolon atamaları
            colValfTipi.FieldName = "ValveType";
            colGazTipi.FieldName = "GasType";
            colBasinc.FieldName = "MaxPressureMbar";
            colBaglantiOlcusu.FieldName = "ConnectionSize";
            colCalismaSicaklikAraligi.FieldName = "TemperatureRange";
        }

        protected override void Listele()
        {
            var liste = _valveService.GetAll().Where(x => x.IsActive == AktifKartlariGoster).ToList();
            Tablo.GridControl.DataSource = liste;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetService<ValfEditForm>(Program.ServiceProvider);
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
                    _valveService.Delete(entityId);
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
