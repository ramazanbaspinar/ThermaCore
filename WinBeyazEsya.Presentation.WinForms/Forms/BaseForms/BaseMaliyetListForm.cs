using DevExpress.XtraEditors;
using WinBeyazEsya.Application.Interfaces.Production;

namespace WinBeyazEsya.Presentation.WinForms.Forms.BaseForms
{
    public partial class BaseMaliyetListForm : BaseListForm
    {
        protected readonly IMaterialCostService _materialCostService;
        protected readonly IServiceProvider _serviceProvider;

        public BaseMaliyetListForm()
        {
            InitializeComponent();
        }

        public BaseMaliyetListForm(IServiceProvider serviceProvider, IMaterialCostService materialCostService) : this()
        {
            _serviceProvider = serviceProvider;
            _materialCostService = materialCostService;
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
                    Tablo.GridControl.DataSource = new System.ComponentModel.BindingList<WinBeyazEsya.Application.DTOs.Production.MaterialCostListDto>(liste);
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
