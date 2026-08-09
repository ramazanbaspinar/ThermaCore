using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Application.Interfaces.Management;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.VergiForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;
using System.Drawing;

namespace WinBeyazEsya.Presentation.WinForms.Forms.ParametrelerForms
{
    public partial class GenelParametrelerEditForm : BaseEditForm
    {
        private readonly ISystemParameterService _systemParameterService;
        private readonly ITaxRateService _taxRateService;
        private SystemParameterDto _currentDto;

        // DI Constructor
        public GenelParametrelerEditForm(
            ISystemParameterService systemParameterService,
            ITaxRateService taxRateService)
        {
            InitializeComponent();
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.GenelParametreler;
            _systemParameterService = systemParameterService;
            _taxRateService = taxRateService;
            
            BaseIslemTuru = ActionType.EntityUpdate;
            DataLayoutControls = new object[] { myDataLayoutControl1, myDataLayoutControl2, myDataLayoutControl3,myDataLayoutControl4 };
        }

        // Tasarımcı veya boş parametreler için varsayılan (olmaması hata verdirebilir diye ekliyoruz)
        public GenelParametrelerEditForm()
        {
            InitializeComponent();
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.GenelParametreler;
        }

        protected override void EventsLoad()
        {
            base.EventsLoad();
            
            if (glfAlisKdv != null) glfAlisKdv.ButtonClick += GlfAlisKdv_ButtonClick;
            if (glfSatisKdv != null) glfSatisKdv.ButtonClick += GlfSatisKdv_ButtonClick;
            if (glfOtv != null) glfOtv.ButtonClick += GlfOtv_ButtonClick;
        }

        public override void Yukle()
        {
            if (btnYeni != null) btnYeni.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (btnSil != null) btnSil.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            // Combobox veri bağlama
            if (cmbYerelParaBirimi != null)
            {
                cmbYerelParaBirimi.Properties.Items.Clear();
                cmbYerelParaBirimi.Properties.Items.AddRange(new[] { "TRY", "USD", "EUR" });
            }

            // GridLookUpFind DataSource bağlama
            var kdvList = _taxRateService?.GetByTaxType(TaxType.Kdv).Where(x => x.IsActive).ToList();
            var otvList = _taxRateService?.GetByTaxType(TaxType.Otv).Where(x => x.IsActive).ToList();

            if (glfAlisKdv != null && kdvList != null)
            {
                glfAlisKdv.Properties.DataSource = kdvList;
                glfAlisKdv.Properties.ValueMember = "Id";
                glfAlisKdv.Properties.DisplayMember = "Rate";
            }

            if (glfSatisKdv != null && kdvList != null)
            {
                glfSatisKdv.Properties.DataSource = kdvList;
                glfSatisKdv.Properties.ValueMember = "Id";
                glfSatisKdv.Properties.DisplayMember = "Rate";
            }

            if (glfOtv != null && otvList != null)
            {
                glfOtv.Properties.DataSource = otvList;
                glfOtv.Properties.ValueMember = "Id";
                glfOtv.Properties.DisplayMember = "Rate";
            }

            // Verileri getir
            try
            {
                _currentDto = _systemParameterService?.GetSystemParameterAsync().GetAwaiter().GetResult() ?? new SystemParameterDto { Id = 0 };
            }
            catch (Exception ex)
            {
                Messages.HataBasligi(ex.Message, "Hata");
                _currentDto = new SystemParameterDto { Id = 0 };
            }
            
            CurrentEntity = _currentDto;
            OldEntity = CloneEntity(CurrentEntity);

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            if (_currentDto == null) return;
            
            if (txtFirmaUnvani != null) txtFirmaUnvani.Text = _currentDto.CompanyName;
            if (txtVergiDairesi != null) txtVergiDairesi.Text = _currentDto.TaxOffice;
            if (txtVergiNo != null) txtVergiNo.Text = _currentDto.TaxNumber;
            if (txtTelefon != null) txtTelefon.Text = _currentDto.PhoneNumber;
            if (txtEmail != null) txtEmail.Text = _currentDto.Email;
            if (txtAdres != null) txtAdres.Text = _currentDto.Address;
            if (cmbYerelParaBirimi != null) cmbYerelParaBirimi.Text = _currentDto.LocalCurrency;
            if (picLogo != null) picLogo.EditValue = _currentDto.Logo;

            if (glfAlisKdv != null) glfAlisKdv.EditValue = _currentDto.DefaultPurchaseKdvId;
            if (glfSatisKdv != null) glfSatisKdv.EditValue = _currentDto.DefaultSalesKdvId;
            if (glfOtv != null) glfOtv.EditValue = _currentDto.DefaultOtvId;

            if (txtFireOrani != null) txtFireOrani.Value = _currentDto.DefaultWastageRate;
            if (txtFirmaBarkodOneki != null) txtFirmaBarkodOneki.Text = _currentDto.CompanyBarcodePrefix;
            
            if (txtGuncellemeYolu != null) txtGuncellemeYolu.Text = _currentDto.GuncellemeYolu;
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new SystemParameterDto
            {
                Id = _currentDto?.Id ?? 0,
                CompanyName = txtFirmaUnvani?.Text,
                TaxOffice = txtVergiDairesi?.Text,
                TaxNumber = txtVergiNo?.Text,
                PhoneNumber = txtTelefon?.Text,
                Email = txtEmail?.Text,
                Address = txtAdres?.Text,
                LocalCurrency = cmbYerelParaBirimi?.Text,
                Logo = picLogo?.EditValue is byte[] b ? b : (picLogo?.EditValue as Image).ToByteArray(),
                CompanyBarcodePrefix = txtFirmaBarkodOneki?.Text,
                GuncellemeYolu = txtGuncellemeYolu?.Text
            };

            if (glfAlisKdv != null && glfAlisKdv.EditValue != null && long.TryParse(glfAlisKdv.EditValue.ToString(), out long aKdv))
                dto.DefaultPurchaseKdvId = aKdv;
            else
                dto.DefaultPurchaseKdvId = null;

            if (glfSatisKdv != null && glfSatisKdv.EditValue != null && long.TryParse(glfSatisKdv.EditValue.ToString(), out long sKdv))
                dto.DefaultSalesKdvId = sKdv;
            else
                dto.DefaultSalesKdvId = null;

            if (glfOtv != null && glfOtv.EditValue != null && long.TryParse(glfOtv.EditValue.ToString(), out long oKdv))
                dto.DefaultOtvId = oKdv;
            else
                dto.DefaultOtvId = null;

            if (txtFireOrani != null) dto.DefaultWastageRate = txtFireOrani.Value;

            CurrentEntity = dto;
        }

        protected override bool EntityInsert()
        {
            return SingletonKaydet();
        }

        protected override bool EntityUpdate()
        {
            return SingletonKaydet();
        }

        private bool SingletonKaydet()
        {
            try
            {
                // Kayıt öncesi nesneyi toparla
                GuncelNesneOlustur();
                _currentDto = (SystemParameterDto)CurrentEntity;

                _systemParameterService.SaveParameterAsync(_currentDto).GetAwaiter().GetResult();
                return true;
            }
            catch (Exception ex)
            {
                Messages.HataBasligi(ex.Message, "Kayıt Hatası");
                return false;
            }
        }

        private void GlfAlisKdv_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Search)
            {
                using var form = new VergiOraniListForm(TaxType.Kdv, _taxRateService);
                form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                if (form.ShowDialog() == DialogResult.OK && form.SelectedEntities != null && form.SelectedEntities.Count > 0)
                {
                    glfAlisKdv.EditValue = form.SelectedEntities[0].Id;
                }
            }
        }

        private void GlfSatisKdv_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Search)
            {
                using var form = new VergiOraniListForm(TaxType.Kdv, _taxRateService);
                form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                if (form.ShowDialog() == DialogResult.OK && form.SelectedEntities != null && form.SelectedEntities.Count > 0)
                {
                    glfSatisKdv.EditValue = form.SelectedEntities[0].Id;
                }
            }
        }

        private void GlfOtv_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Search)
            {
                using var form = new VergiOraniListForm(TaxType.Otv, _taxRateService);
                form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                if (form.ShowDialog() == DialogResult.OK && form.SelectedEntities != null && form.SelectedEntities.Count > 0)
                {
                    glfOtv.EditValue = form.SelectedEntities[0].Id;
                }
            }
        }
    }
}

