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
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Application.Interfaces.Production;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.GazForms
{
    public partial class GazListForm : BaseListForm
    {
        private readonly IGasValveService _gasValveService;

        // Designer için parametresiz kurucu (DevExpress Designer hatasını önler)
        public GazListForm()
        {
            InitializeComponent();
        }

        // DI Constructor
        public GazListForm(IGasValveService gasValveService)
        {
            InitializeComponent();
            _gasValveService = gasValveService;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = ThermaCore.Domain.Enums.ModuleType.GazMusluguTanimlari;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
            
            // Tasarıma dokunmadan fieldnameleri fixliyoruz
            colGazTipi.FieldName = "GasType";
            colEmniyetVentili.FieldName = "HasSafetyValve";
            colCikisAcisi.FieldName = "OutletAngle";
            colMilTipi.FieldName = "ShaftType";
        }

        protected override void Listele()
        {
            var liste = _gasValveService.GetAll().Where(x => x.IsActive == AktifKartlariGoster).ToList();
            Tablo.GridControl.DataSource = liste;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetService(typeof(GazMusluguEditForm)) as GazMusluguEditForm;
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
                    _gasValveService.Delete(entityId);
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