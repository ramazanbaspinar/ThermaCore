using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.AteslemeTrafosuForms
{
    public partial class AteslemeTrafosuListForm : BaseListForm
    {
        private readonly IIgnitionTransformerService _service;

        public AteslemeTrafosuListForm()
        {
            InitializeComponent();
            _service = Program.ServiceProvider.GetRequiredService<IIgnitionTransformerService>();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = ModuleType.AteslemeTrafosuTanimlari;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
        }

        protected override void Listele()
        {
            var liste = _service.GetAll().Where(x => x.IsActive == AktifKartlariGoster).ToList();
            Tablo.GridControl.DataSource = liste;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<AteslemeTrafosuEditForm>();
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

            long id = 0;
            long.TryParse(Tablo.GetFocusedRowCellValue("Id")?.ToString(), out id);
            
            if (id <= 0) return;

            var result = Messages.SilMesaj(Tablo.GetRowCellValue(Tablo.FocusedRowHandle, "Name")?.ToString() ?? "Ateşleme Trafosu");
            if (result == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _service.Delete(id);
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
