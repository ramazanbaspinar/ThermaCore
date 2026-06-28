using DevExpress.XtraEditors;
using System;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Management;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.VergiForms
{
    public partial class VergiOraniEditForm : BaseEditForm
    {
        private readonly ITaxRateService _taxRateService = default!;
        private readonly TaxType _taxType;

        public VergiOraniEditForm()
        {
            InitializeComponent();
        }

        public VergiOraniEditForm(TaxType taxType, ITaxRateService taxRateService)
        {
            InitializeComponent();
            _taxType = taxType;
            _taxRateService = taxRateService;

            // BaseEditForm ayarları
            BaseKartTuru = _taxType == TaxType.Kdv ? ModuleType.KdvOranlari : ModuleType.OtvOranlari;
            DataLayoutControl = myDataLayoutControl1;
        }

        public override void Yukle()
        {
            this.Text = _taxType.ToName() + " Oranı Kartı";
            
            // ComboBox'ı ayarla
            cmbVergiTuru.Properties.Items.Clear();
            cmbVergiTuru.Properties.Items.Add(_taxType.ToName());
            cmbVergiTuru.SelectedIndex = 0;
            cmbVergiTuru.ReadOnly = true;

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                var entity = _taxRateService.GetById(Id);
                CurrentEntity = entity;
            }
            else
            {
                CurrentEntity = new TaxRateDto 
                { 
                    TaxType = _taxType,
                    IsActive = true 
                };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (TaxRateDto)CurrentEntity;

            txtKod.Text = dto.Code;
            txtOran.EditValue = dto.Rate;
            myMemoEdit1.Text = dto.Description;
            tglDurum.IsOn = dto.IsActive;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new TaxRateDto
            {
                Id = this.Id,
                TaxType = _taxType,
                Code = txtKod.Text,
                Rate = Convert.ToDecimal(txtOran.EditValue),
                Description = myMemoEdit1.Text,
                IsActive = tglDurum.IsOn
            };
        }

        protected override bool EntityInsert()
        {
            var dto = (TaxRateDto)CurrentEntity;
            dto.Id = BaseIslemTuru.IdOlustur(dto);
            Id = _taxRateService.Insert(dto);
            return Id > 0;
        }

        protected override bool EntityUpdate()
        {
            var dto = (TaxRateDto)CurrentEntity;
            _taxRateService.Update(dto);
            return true;
        }

        protected override void EntityDelete()
        {
            if (Id <= 0) return;

            if (ThermaCore.Presentation.WinForms.Helpers.Messages.SilMesaj("Vergi Oranı") == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                    _taxRateService.Delete(Id);
                    RefreshYapilacak = true;
                    ThermaCore.Presentation.WinForms.Helpers.Messages.SilindiMesaj();
                    Close();
                }
                catch (System.Exception ex)
                {
                    ThermaCore.Presentation.WinForms.Helpers.Messages.HataBasligi($"Hata oluştu:\n{ex.Message}", "Hata");
                }
                finally
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                }
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return !System.Linq.Enumerable.Any(System.Linq.Enumerable.Where(_taxRateService.GetAll(), x => x.Code == code));
        }
    }
}