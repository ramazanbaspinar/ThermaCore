using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Application.Interfaces.Management;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.VergiForms
{
    public partial class VergiOraniListForm : BaseListForm
    {
        private readonly ITaxRateService _taxRateService = default!;
        private readonly TaxType _taxType;

        public VergiOraniListForm()
        {
            InitializeComponent();
        }

        public VergiOraniListForm(TaxType taxType, ITaxRateService taxRateService)
        {
            InitializeComponent();
            _taxType = taxType;
            _taxRateService = taxRateService;

            this.Text = _taxType.ToName() + " Oranları";
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1; // Tasarımdaki grid view ismi neyse onu yazmalı. myGridView1 miş promptta
            BaseKartTuru = _taxType == TaxType.Kdv ? ModuleType.KdvOranlari : ModuleType.OtvOranlari;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
            myGridView1.ViewCaption = this.Text; // İstenen yeni kural
        }

        protected override void Listele()
        {
            var entities = _taxRateService.GetByTaxType(_taxType).Where(x => x.IsActive == AktifKartlariGoster).ToList();
            Tablo.GridControl.DataSource = entities;
        }

        protected override void ShowEditForm(long id)
        {
            // Transient olduğu için ActivatorUtilities ile TaxType parametresini de geçerek oluşturuyoruz.
            var form = ActivatorUtilities.CreateInstance<VergiOraniEditForm>(Program.ServiceProvider, _taxType);
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

            if (XtraMessageBox.Show("Seçili kaydı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _taxRateService.Delete(entityId);
                    Listele();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
