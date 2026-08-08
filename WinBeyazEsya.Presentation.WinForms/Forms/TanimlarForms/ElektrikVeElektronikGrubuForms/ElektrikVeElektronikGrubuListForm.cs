using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.ElektrikVeElektronikGrubuForms
{
    public partial class ElektrikVeElektronikGrubuListForm : BaseListForm
    {
        private readonly WinBeyazEsya.Application.Interfaces.Definitions.IElectricalElectronicGroupService _electricalElectronicGroupService = default!;
        private readonly IServiceProvider _serviceProvider = default!;

        public ElektrikVeElektronikGrubuListForm()
        {
            InitializeComponent();
        }

        public ElektrikVeElektronikGrubuListForm(
            WinBeyazEsya.Application.Interfaces.Definitions.IElectricalElectronicGroupService electricalElectronicGroupService,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();

            if (!DesignMode && Program.ServiceProvider != null)
            {
                _electricalElectronicGroupService = electricalElectronicGroupService;
                _serviceProvider = serviceProvider;
                Bll = _electricalElectronicGroupService;
            }

            ShowItems = new DevExpress.XtraBars.BarItem[] { btnYeni, btnSil, btnYenile };
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = Domain.Enums.ModuleType.ElektrikVeElektronikGrubu;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
        }

        protected override void Listele()
        {
            var liste = _electricalElectronicGroupService.GetAll().Where(x => x.IsActive == AktifKartlariGoster);
            
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
                var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ElektrikVeElektronikGrubuEditForm>(_serviceProvider);
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
                    _electricalElectronicGroupService.Delete(entityId);
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