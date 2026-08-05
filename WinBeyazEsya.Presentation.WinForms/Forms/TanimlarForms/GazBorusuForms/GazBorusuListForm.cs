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
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.GazBorusuForms
{
    public partial class GazBorusuListForm : BaseListForm
    {
        private readonly IGasPipeService _service;

        public GazBorusuListForm()
        {
            InitializeComponent();
            _service = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<WinBeyazEsya.Application.Interfaces.Production.IGasPipeService>(Program.ServiceProvider);
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.GazBorusuTanimlari;
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
            var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<GazBorusuEditForm>(Program.ServiceProvider);
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

            var result = WinBeyazEsya.Presentation.WinForms.Helpers.Messages.SilMesaj(Tablo.GetRowCellValue(Tablo.FocusedRowHandle, "Name")?.ToString() ?? "Gaz Borusu");
            if (result == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _service.Delete(id);
                    Listele();
                    WinBeyazEsya.Presentation.WinForms.Helpers.Messages.SilindiMesaj();
                }
                catch (Exception ex)
                {
                    WinBeyazEsya.Presentation.WinForms.Helpers.Messages.HataBasligi(ex.Message, "Silme Hatası");
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }
    }
}
