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
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.DepoTanimForms
{
    public partial class DepoTanimListForm : BaseListForm
    {
        private readonly WinBeyazEsya.Application.Interfaces.Definitions.IWarehouseService? _warehouseService;
        private readonly IServiceProvider _serviceProvider = default!;

        public DepoTanimListForm()
        {
            InitializeComponent();
        }

        public DepoTanimListForm(
            WinBeyazEsya.Application.Interfaces.Definitions.IWarehouseService? warehouseService,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.Warehouse;
            
            if (!DesignMode && Program.ServiceProvider != null)
            {
                _warehouseService = warehouseService;
                _serviceProvider = serviceProvider;
                Bll = _warehouseService;
            }

            Tablo = myGridView1;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;

            colId.FieldName = "Id";
            colKod.FieldName = "Code";
            colDepoAdi.FieldName = "Name";
            colYetkiliKisi.FieldName = "AuthorizedPerson";
            colAciklama.FieldName = "Description";
            
            ShowItems = new DevExpress.XtraBars.BarItem[] { btnYeni, btnSil, btnYenile };
        }

        protected override void Listele()
        {
            if (_warehouseService != null)
            {
                var liste = _warehouseService.GetAll().Where(x => x.IsActive == AktifKartlariGoster);
                
                if (ListeDisiTutulacakKayitlar != null && ListeDisiTutulacakKayitlar.Any())
                {
                    liste = liste.Where(x => !ListeDisiTutulacakKayitlar.Contains(x.Id));
                }
                
                Tablo.GridControl.DataSource = liste.ToList();
            }
        }

        protected override void ShowEditForm(long id)
        {
            if (_serviceProvider != null)
            {
                var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<DepoTanimEditForm>(_serviceProvider);
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
            if (Tablo.FocusedRowHandle < 0 || _warehouseService == null) return;

            long entityId = 0;
            long.TryParse(Tablo.GetFocusedRowCellValue("Id")?.ToString(), out entityId);
            
            if (entityId <= 0) return;

            var result = Helpers.Messages.SilMesaj(Tablo.GetRowCellValue(Tablo.FocusedRowHandle, "Name")?.ToString() ?? "");
            if (result == DialogResult.Yes)
            {
                try
                {
                    _warehouseService.Delete(entityId);
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