using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MotorForms
{
    public partial class MotorListForm : BaseListForm
    {
        private readonly IOvenMotorService _ovenMotorService = default!;

        // Designer için parametresiz kurucu (DevExpress Designer hatasını önler)
        public MotorListForm()
        {
            InitializeComponent();
        }

        // DI Constructor
        public MotorListForm(IOvenMotorService ovenMotorService)
        {
            InitializeComponent();
            _ovenMotorService = ovenMotorService;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = ModuleType.MotorTanimlari;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
            
            // Tasarıma dokunmadan fieldnameleri fixliyoruz
            colMotorTipi.FieldName = "MotorTypeName";
            colMilUzunlugu.FieldName = "ShaftLengthMm";
        }

        protected override void Listele()
        {
            var liste = _ovenMotorService.GetAllList();
            if (!AktifKartlariGoster)
                liste = liste.Where(x => !x.IsActive).ToList();
            else
                liste = liste.Where(x => x.IsActive).ToList();

            Tablo.GridControl.DataSource = liste;
        }

        protected override void ShowEditForm(long id)
        {
            // Transient DI üzerinden Edit formunu alıp açıyoruz.
            var form = Program.ServiceProvider.GetService(typeof(MotorEditForm)) as MotorEditForm;
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

            if (Messages.SilMesaj("Motor Tanımı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _ovenMotorService.Delete(entityId);
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
