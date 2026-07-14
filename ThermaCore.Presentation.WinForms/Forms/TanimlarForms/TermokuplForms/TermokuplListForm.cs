using System.Linq;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Application.Interfaces.Production;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.TermokuplForms
{
    public partial class TermokuplListForm : BaseListForm
    {
        private readonly IThermocoupleService _thermocoupleService = default!;

        public TermokuplListForm()
        {
            InitializeComponent();
        }

        public TermokuplListForm(IThermocoupleService thermocoupleService)
        {
            InitializeComponent();
            _thermocoupleService = thermocoupleService;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = ThermaCore.Domain.Enums.ModuleType.TermokuplTanimlari;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
            
            colTermokuplAdi.FieldName = "Name";
            colUzunluk.FieldName = "LengthMm";
            colKafaTipi.FieldName = "HeadType";
            colUcTipi.FieldName = "TipType";
            colAciklama.FieldName = "Description";
        }

        protected override void Listele()
        {
            var liste = _thermocoupleService.GetAll().Where(x => x.IsActive == AktifKartlariGoster).ToList();
            Tablo.GridControl.DataSource = liste;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetService<TermokuplEditForm>(Program.ServiceProvider);
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

            var result = ThermaCore.Presentation.WinForms.Helpers.Messages.SilMesaj(Tablo.GetRowCellValue(Tablo.FocusedRowHandle, "Name")?.ToString() ?? "");
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    _thermocoupleService.Delete(entityId);
                    Listele();
                }
                catch (System.Exception ex)
                {
                    ThermaCore.Presentation.WinForms.Helpers.Messages.HataBasligi(ex.Message, "Silme Hatası");
                }
            }
        }
    }
}