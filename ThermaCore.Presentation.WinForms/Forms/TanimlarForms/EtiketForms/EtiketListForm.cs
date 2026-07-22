using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Application.Interfaces.Definitions;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.EtiketForms
{
    public partial class EtiketListForm : BaseListForm
    {
        private readonly IProductLabelService _productLabelService;

        public EtiketListForm()
        {
            InitializeComponent();
            _productLabelService = Program.ServiceProvider.GetRequiredService<IProductLabelService>();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = ModuleType.EtiketTanimlari;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
        }

        protected override void Listele()
        {
            var liste = _productLabelService.GetAll().Where(x => x.IsActive == AktifKartlariGoster).ToList();
            Tablo.GridControl.DataSource = liste;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<EtiketEditForm>();
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

            string itemName = Tablo.GetFocusedRowCellValue("Name")?.ToString() ?? "Kayıt";
            if (Messages.SilMesaj(itemName) == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _productLabelService.Delete(entityId);
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