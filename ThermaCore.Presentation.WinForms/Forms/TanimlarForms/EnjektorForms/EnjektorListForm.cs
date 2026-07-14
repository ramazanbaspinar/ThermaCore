using System.Linq;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Application.Interfaces.Production;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.EnjektorForms
{
    public partial class EnjektorListForm : BaseListForm
    {
        private readonly IInjectorService _injectorService;

        public EnjektorListForm()
        {
            InitializeComponent();
        }

        public EnjektorListForm(IInjectorService injectorService)
        {
            InitializeComponent();
            _injectorService = injectorService;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = ThermaCore.Domain.Enums.ModuleType.EnjektorTanimlari;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
            
            // Kolon atamaları
            colGazTipi.FieldName = "GasType";
            colBekUyumu.FieldName = "TargetBurner";
            colDelikCapi.FieldName = "HoleDiameterMm";
            colDisOlcusu.FieldName = "ThreadSize";
        }

        protected override void Listele()
        {
            var liste = _injectorService.GetAll().Where(x => x.IsActive == AktifKartlariGoster).ToList();
            Tablo.GridControl.DataSource = liste;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetService(typeof(EnjektorEditForm)) as EnjektorEditForm;
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

            try
            {
                _injectorService.Delete(entityId);
                Listele();
            }
            catch (System.Exception ex)
            {
                ThermaCore.Presentation.WinForms.Helpers.Messages.HataBasligi(ex.Message, "Silme Hatası");
            }
        }
    }
}