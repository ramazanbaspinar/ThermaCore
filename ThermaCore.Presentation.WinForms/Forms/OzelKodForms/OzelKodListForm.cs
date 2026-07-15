using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThermaCore.Application.Interfaces.Common;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.OzelKodForms
{
    public partial class OzelKodListForm : BaseListForm
    {
        private readonly ISpecialCodeService _specialCodeService;
        private readonly SpecialCodeType _codeType;
        private readonly string _entityType;

        public OzelKodListForm(params object[] prm)
        {
            InitializeComponent();
            _specialCodeService = Program.ServiceProvider.GetRequiredService<ISpecialCodeService>();

            if (prm != null && prm.Length >= 2)
            {
                _codeType = (SpecialCodeType)prm[0];
                _entityType = (string)prm[1];
            }
            else
            {
                throw new ArgumentException("OzelKodListForm params object[] prm eksik! (SpecialCodeType ve EntityType gerekli)");
            }

            // Form Title (Text) and GridView Caption update dynamically
            string titlePrefix = _codeType == SpecialCodeType.SpecialCode ? "Özel Kod Kayıtları" : "Grup Kodu Kayıtları";
            
            string entityNameTr = _entityType switch
            {
                "Screw" => "Vida",
                "QualityStandard" => "Kalite Standardı",
                "GasValve" => "Gaz Musluğu",
                "Burner" => "Bek Grubu",
                "Terminal" => "Terminal Cihazı",
                "Termostat" => "Termostat",
                "Timer" => "Timer",
                "Knob" => "Düğme",
                "OvenGlass" => "Cam",
                "GlassType" => "Cam Tipi",
                "ColorFeature" => "Cam Renk Özellik",
                "Cable" => "Kablo",
                "Hotplate" => "Pleyt Isıtıcı",
                "OvenLamp" => "Lamba",
                "OvenMotor" => "Motor",
                "OvenFan" => "Fan / Pervane",
                "Injector" => "Enjektör Tanımları",
                "Valve" => "Valf Tanımları",
                "Thermocouple" => "Termokupl (Emniyet) Tanımları",
                "SparkPlug" => "Çakmak (Buji) Tanımları",
                "IgnitionTransformer" => "Ateşleme Trafosu Tanımları",
                "GasPipe" => "Gaz Borusu Tanımları",
                _ => _entityType
            };

            this.Text = $"{titlePrefix} ({entityNameTr})";
            
            if (myGridView1 != null)
                myGridView1.ViewCaption = this.Text;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = ModuleType.KodYonetimi;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
        }

        protected override void Listele()
        {
            var liste = _specialCodeService.GetCodes(_codeType, _entityType);
            Tablo.GridControl.DataSource = liste;
        }

        protected override void ShowEditForm(long id)
        {
            var form = new OzelKodEditForm(_codeType, _entityType);
            form.IdAtaVeAc(id);
            Listele();
            if (form.Id > 0)
            {
                Tablo.RowFocus("Id", form.Id);
            }
        }
        
        protected override void EntityDelete()
        {
            if (Tablo.FocusedRowHandle < 0) return;

            long entityId = 0;
            long.TryParse(Tablo.GetFocusedRowCellValue("Id")?.ToString(), out entityId);
            
            if (entityId <= 0) return;

            string msgName = _codeType == SpecialCodeType.SpecialCode ? "Özel Kod" : "Grup Kodu";

            if (Messages.SilMesaj(msgName) == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _specialCodeService.Delete(entityId);
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