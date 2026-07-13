using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;
using ThermaCore.Application.Interfaces.Production;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.FanForms
{
    public partial class FanListForm : BaseListForm
    {
        private readonly IOvenFanService _ovenFanService = default!;
        private readonly IServiceProvider _serviceProvider = default!;

        // Designer için parametresiz kurucu
        public FanListForm()
        {
            InitializeComponent();
        }

        // DI Constructor
        public FanListForm(IOvenFanService ovenFanService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _ovenFanService = ovenFanService;
            _serviceProvider = serviceProvider;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = ModuleType.FanTanimlari;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
            
            // Tasarıma dokunmadan fieldnameleri fixliyoruz
            colFanTipi.FieldName = "FanType"; // Enum açıklaması grid'de DevExpress ImageComboBox ile halledilmiş varsayılır veya mapping'de halledilebilir.
            // DTO'da FanType enum. DevExpress grid'de RepositoryItemImageComboBox kullanılırsa enum direkt uyar.
        }

        protected override void Listele()
        {
            var liste = _ovenFanService.GetAllList();
            if (!AktifKartlariGoster)
                liste = liste.Where(x => !x.IsActive).ToList();
            else
                liste = liste.Where(x => x.IsActive).ToList();

            Tablo.GridControl.DataSource = liste;
        }

        protected override void ShowEditForm(long id)
        {
            // Program.ServiceProvider KESİNLİKLE YASAK, constructor'dan gelen _serviceProvider kullanılır!
            var form = _serviceProvider.GetRequiredService<FanEditForm>();
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

            if (Messages.SilMesaj("Fan / Pervane Tanımı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _ovenFanService.Delete(entityId);
                    Listele();
                    Messages.SilindiMesaj();
                }
                catch (Exception ex)
                {
                    Messages.HataBasligi(ex.Message, "Silme Hatası");
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }
    }
}