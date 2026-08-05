using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.LambaForms
{
    public partial class LambaListForm : BaseListForm
    {
        private readonly IOvenLampService _ovenLampService = default!;

        // Designer için parametresiz kurucu (DevExpress Designer hatasını önler)
        public LambaListForm()
        {
            InitializeComponent();
        }

        // DI Constructor
        public LambaListForm(IOvenLampService ovenLampService)
        {
            InitializeComponent();
            _ovenLampService = ovenLampService;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = ModuleType.LambaTanimlari;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
        }

        protected override void Listele()
        {
            var liste = _ovenLampService.GetAll();
            if (!AktifKartlariGoster)
                liste = liste.Where(x => !x.IsActive).ToList();
            else
                liste = liste.Where(x => x.IsActive).ToList();

            Tablo.GridControl.DataSource = liste;
        }

        protected override void ShowEditForm(long id)
        {
            // Transient DI üzerinden Edit formunu alıp açıyoruz.
            var form = Program.ServiceProvider.GetService(typeof(LambaEditForm)) as LambaEditForm;
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

            if (Messages.SilMesaj("Lamba Tanımı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _ovenLampService.Delete(entityId);
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
