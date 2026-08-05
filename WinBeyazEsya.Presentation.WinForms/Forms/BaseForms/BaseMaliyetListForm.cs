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
using WinBeyazEsya.Application.Interfaces.Production;
using Microsoft.Extensions.DependencyInjection;

namespace WinBeyazEsya.Presentation.WinForms.Forms.BaseForms
{
    public partial class BaseMaliyetListForm : BaseListForm
    {
        protected readonly IMaterialCostService _materialCostService;

        public BaseMaliyetListForm()
        {
            InitializeComponent();
            if (!IsDesignMode && Program.ServiceProvider != null)
            {
                _materialCostService = Program.ServiceProvider.GetService<IMaterialCostService>();
            }
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            Navigator = longNavigator1.Navigator;
        }

        protected virtual void MalzemeAdlariniDoldur(IEnumerable<WinBeyazEsya.Application.DTOs.Production.MaterialCostListDto> liste)
        {
            // Türeyen sınıflar kendi malzeme isimlerini bu metotla dolduracak.
        }

        protected override void Listele()
        {
            if (Tablo != null)
            {
                Tablo.ViewCaption = this.Text;

                if (_materialCostService != null && (int)BaseKartTuru != 0)
                {
                    var liste = _materialCostService.GetAllByMaterialType(BaseKartTuru).ToList();
                    MalzemeAdlariniDoldur(liste);
                    Tablo.GridControl.DataSource = liste;
                }
            }
        }

        protected override void EntityDelete()
        {
            if (Tablo == null) return;
            
            var entity = Tablo.GetRow(Tablo.FocusedRowHandle) as WinBeyazEsya.Application.DTOs.Production.MaterialCostListDto;
            if (entity == null) return;

            if (WinBeyazEsya.Presentation.WinForms.Helpers.Messages.SilMesaj("Maliyet Kaydı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _materialCostService?.Delete(entity.Id);
                    WinBeyazEsya.Presentation.WinForms.Helpers.Messages.SilindiMesaj();
                    Listele();
                }
                catch (FluentValidation.ValidationException ex)
                {
                    XtraMessageBox.Show(ex.Message, "Silme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
