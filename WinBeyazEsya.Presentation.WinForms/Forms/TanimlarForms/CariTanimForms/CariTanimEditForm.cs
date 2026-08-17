using System;
using System.Linq;
using System.Windows.Forms;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Common;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.CariTanimForms
{
    public partial class CariTanimEditForm : BaseEditForm
    {
        private readonly ICurrentAccountService _currentAccountService = default!;
        private readonly ICountryService _countryService = default!;
        private readonly ICityService _cityService = default!;
        private readonly ITownService _townService = default!;
        private readonly ISpecialCodeService _specialCodeService = default!;

        protected override string CodeControlName => "txtCode"; 

        public CariTanimEditForm() { InitializeComponent(); }

        public CariTanimEditForm(
            ICurrentAccountService currentAccountService,
            ICountryService countryService,
            ICityService cityService,
            ITownService townService,
            ISpecialCodeService specialCodeService)
        {
            InitializeComponent();
            if (!DesignMode && Program.ServiceProvider != null)
            {
                _currentAccountService = currentAccountService;
                _countryService = countryService;
                _cityService = cityService;
                _townService = townService;
                _specialCodeService = specialCodeService;
                Bll = _currentAccountService;
            }
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.CurrentAccount;
            RequiresCodeTemplate = true;
            EventsLoad();
        }

        public override void Yukle()
        {
            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                CurrentEntity = new CurrentAccountDto { Active = 1, ShortCode = "" };
                Id = BaseIslemTuru.IdOlustur(OldEntity);
            }
            else
            {
                CurrentEntity = _currentAccountService.GetById(Id);
            }
            NesneyiKontrollereBagla();
        }

        private bool _eventsAttached = false;
        protected override void EventsLoad()
        {
            base.EventsLoad();
            if (_eventsAttached) return;
            _eventsAttached = true;

            var cmbCardType = this.Controls.Find("cmbCardType", true).FirstOrDefault() as DevExpress.XtraEditors.ComboBoxEdit;
            if (cmbCardType != null)
            {
                cmbCardType.Properties.Items.Clear();
                foreach (CardType type in Enum.GetValues(typeof(CardType)))
                {
                    cmbCardType.Properties.Items.Add(WinBeyazEsya.Domain.Helpers.EnumFunctions.GetDescription(type));
                }
            }

            var cmbCurrencyId = this.Controls.Find("cmbCurrencyId", true).FirstOrDefault() as DevExpress.XtraEditors.ComboBoxEdit;
            if (cmbCurrencyId != null)
            {
                cmbCurrencyId.Properties.Items.Clear();
                foreach (WinBeyazEsya.Domain.Enums.CurrencyType type in Enum.GetValues(typeof(WinBeyazEsya.Domain.Enums.CurrencyType)))
                {
                    cmbCurrencyId.Properties.Items.Add(WinBeyazEsya.Domain.Helpers.EnumFunctions.GetDescription(type));
                }
            }

            var cmbPaymentType = this.Controls.Find("cmbPaymentType", true).FirstOrDefault() as DevExpress.XtraEditors.ComboBoxEdit;
            if (cmbPaymentType != null)
            {
                cmbPaymentType.Properties.Items.Clear();
                foreach (WinBeyazEsya.Domain.Enums.PaymentType type in Enum.GetValues(typeof(WinBeyazEsya.Domain.Enums.PaymentType)))
                {
                    cmbPaymentType.Properties.Items.Add(WinBeyazEsya.Domain.Helpers.EnumFunctions.GetDescription(type));
                }
            }

            var glufCountry = this.Controls.Find("glufCountry", true).FirstOrDefault() as WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyGridLookUpFind;
            var glufCity = this.Controls.Find("glufCity", true).FirstOrDefault() as WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyGridLookUpFind;
            var glufTown = this.Controls.Find("glufTown", true).FirstOrDefault() as WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyGridLookUpFind;
            var glufSpecialCode = this.Controls.Find("glufSpecialCode", true).FirstOrDefault() as WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyGridLookUpFind;

            if (glufCountry != null)
            {
                glufCountry.Properties.DataSource = _countryService.GetAll().ToList();
                glufCountry.Properties.ValueMember = "Id"; 
                glufCountry.Properties.DisplayMember = "Title";
                
                glufCountry.EditValueChanged += (s, e) =>
                {
                    if (glufCity != null) 
                    {
                        glufCity.EditValue = null;
                        glufCity.Properties.Buttons[1].Enabled = false;
                    }
                    if (glufTown != null) 
                    {
                        glufTown.EditValue = null;
                        glufTown.Properties.Buttons[1].Enabled = false;
                    }

                    if (long.TryParse(glufCountry.EditValue?.ToString(), out long selectedCountryId))
                    {
                        var selectedCountry = _countryService.GetById(selectedCountryId);
                        if (selectedCountry != null && glufCity != null)
                        {
                            glufCity.Properties.DataSource = _cityService.GetAll().Where(x => x.CountryId == selectedCountry.Id).ToList();
                            glufCity.Properties.Buttons[1].Enabled = true;
                        }
                    }
                };

                glufCountry.SearchButtonClicked += (s, e) =>
                {
                    var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.UlkeTanimForm.UlkeTanimListForm>(Program.ServiceProvider);
                    form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                    form.ShowDialog();
                    if (form.DialogResult == System.Windows.Forms.DialogResult.OK && form.SelectedEntities?.Count > 0)
                    {
                        glufCountry.Properties.DataSource = _countryService.GetAll().ToList();
                        var selectedItem = form.SelectedEntities[0] as WinBeyazEsya.Application.DTOs.Definitions.CountryDto;
                        if (selectedItem != null)
                        {
                            glufCountry.EditValue = selectedItem.Id;
                        }
                    }
                };
            }

            if (glufCity != null)
            {
                glufCity.Properties.ValueMember = "Id";
                glufCity.Properties.DisplayMember = "Title";
                glufCity.Properties.Buttons[1].Enabled = false; // Initially disabled
                
                glufCity.EditValueChanged += (s, e) =>
                {
                    if (glufTown != null)
                    {
                        glufTown.EditValue = null;
                        glufTown.Properties.Buttons[1].Enabled = false;
                    }

                    if (long.TryParse(glufCity.EditValue?.ToString(), out long selectedCityId))
                    {
                        var selectedCity = _cityService.GetById(selectedCityId);
                        if (selectedCity != null && glufTown != null)
                        {
                            glufTown.Properties.DataSource = _townService.GetAll().Where(x => x.CityId == selectedCity.Id).ToList();
                            glufTown.Properties.Buttons[1].Enabled = true;
                        }
                    }
                };

                glufCity.SearchButtonClicked += (s, e) =>
                {
                    if (glufCountry?.EditValue == null) return;
                    if (!long.TryParse(glufCountry.EditValue.ToString(), out long selectedCountryId)) return;

                    var selectedCountry = _countryService.GetById(selectedCountryId);
                    if (selectedCountry == null) return;

                    var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.IlTanimForms.IlTanimListForm>(Program.ServiceProvider);
                    form.SetUlke(selectedCountry.Id, selectedCountry.Title);
                    form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                    form.ShowDialog();
                    if (form.DialogResult == System.Windows.Forms.DialogResult.OK && form.SelectedEntities?.Count > 0)
                    {
                        glufCity.Properties.DataSource = _cityService.GetAll().Where(x => x.CountryId == selectedCountry.Id).ToList();
                        var selectedItem = form.SelectedEntities[0] as WinBeyazEsya.Application.DTOs.Definitions.CityDto;
                        if (selectedItem != null)
                        {
                            glufCity.EditValue = selectedItem.Id;
                        }
                    }
                };
            }

            if (glufTown != null)
            {
                glufTown.Properties.ValueMember = "Id";
                glufTown.Properties.DisplayMember = "Title";
                glufTown.Properties.Buttons[1].Enabled = false; // Initially disabled

                glufTown.SearchButtonClicked += (s, e) =>
                {
                    if (glufCity?.EditValue == null) return;
                    if (!long.TryParse(glufCity.EditValue.ToString(), out long selectedCityId)) return;

                    var selectedCity = _cityService.GetById(selectedCityId);
                    if (selectedCity == null) return;

                    var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.IlceTanimForms.IlceTanimListForm>(Program.ServiceProvider);
                    form.SetIl(selectedCity.Id, selectedCity.Title);
                    form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                    form.ShowDialog();
                    if (form.DialogResult == System.Windows.Forms.DialogResult.OK && form.SelectedEntities?.Count > 0)
                    {
                        glufTown.Properties.DataSource = _townService.GetAll().Where(x => x.CityId == selectedCity.Id).ToList();
                        var selectedItem = form.SelectedEntities[0] as WinBeyazEsya.Application.DTOs.Definitions.TownDto;
                        if (selectedItem != null)
                        {
                            glufTown.EditValue = selectedItem.Id;
                        }
                    }
                };
            }

            if (glufSpecialCode != null)
            {
                glufSpecialCode.Properties.DataSource = _specialCodeService.GetCodes(WinBeyazEsya.Domain.Enums.SpecialCodeType.SpecialCode, "CurrentAccount");
                glufSpecialCode.Properties.ValueMember = "Name";
                glufSpecialCode.Properties.DisplayMember = "Name";

                glufSpecialCode.SearchButtonClicked += (s, e) =>
                {
                    var form = new WinBeyazEsya.Presentation.WinForms.Forms.OzelKodForms.OzelKodListForm(WinBeyazEsya.Domain.Enums.SpecialCodeType.SpecialCode, "CurrentAccount");
                    form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                    form.ShowDialog();
                    if (form.DialogResult == System.Windows.Forms.DialogResult.OK && form.SelectedEntities?.Count > 0)
                    {
                        glufSpecialCode.Properties.DataSource = _specialCodeService.GetCodes(WinBeyazEsya.Domain.Enums.SpecialCodeType.SpecialCode, "CurrentAccount");
                        var selectedItem = form.SelectedEntities[0] as WinBeyazEsya.Application.DTOs.Common.SpecialCodeDto;
                        if (selectedItem != null)
                        {
                            glufSpecialCode.EditValue = selectedItem.Name;
                        }
                    }
                };
            }
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (CurrentAccountDto)CurrentEntity;
            var txtCode = this.Controls.Find("txtCode", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var txtTitle = this.Controls.Find("txtTitle", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var txtShortCode = this.Controls.Find("txtShortCode", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var tglActive = this.Controls.Find("tgsIsActive", true).FirstOrDefault() as DevExpress.XtraEditors.ToggleSwitch;
            
            var cmbCardType = this.Controls.Find("cmbCardType", true).FirstOrDefault() as DevExpress.XtraEditors.ComboBoxEdit;
            var glufSpecialCode = this.Controls.Find("glufSpecialCode", true).FirstOrDefault() as DevExpress.XtraEditors.GridLookUpEdit;
            var txtAuthorizedPerson = this.Controls.Find("txtAuthorizedPerson", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var glufCountry = this.Controls.Find("glufCountry", true).FirstOrDefault() as DevExpress.XtraEditors.GridLookUpEdit;
            var glufCity = this.Controls.Find("glufCity", true).FirstOrDefault() as DevExpress.XtraEditors.GridLookUpEdit;
            var glufTown = this.Controls.Find("glufTown", true).FirstOrDefault() as DevExpress.XtraEditors.GridLookUpEdit;
            var memAddress = this.Controls.Find("memAddress", true).FirstOrDefault() as DevExpress.XtraEditors.MemoEdit;
            var txtPhone1 = this.Controls.Find("txtPhone1", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var txtPhone2 = this.Controls.Find("txtPhone2", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var txtMobilePhone = this.Controls.Find("txtMobilePhone", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var txtEmail = this.Controls.Find("txtEmail", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var txtWebAddress = this.Controls.Find("txtWebAddress", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var txtTaxOffice = this.Controls.Find("txtTaxOffice", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var txtTaxNumber = this.Controls.Find("txtTaxNumber", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;

            var cmbCurrencyId = this.Controls.Find("cmbCurrencyId", true).FirstOrDefault() as DevExpress.XtraEditors.ComboBoxEdit;
            var cmbPaymentType = this.Controls.Find("cmbPaymentType", true).FirstOrDefault() as DevExpress.XtraEditors.ComboBoxEdit;
            var spnMaturityDays = this.Controls.Find("spnMaturityDays", true).FirstOrDefault() as DevExpress.XtraEditors.SpinEdit;
            var chkIsEInvoiceUser = this.Controls.Find("chkIsEInvoiceUser", true).FirstOrDefault() as DevExpress.XtraEditors.CheckEdit;
            var chkIsEDispatchUser = this.Controls.Find("chkIsEDispatchUser", true).FirstOrDefault() as DevExpress.XtraEditors.CheckEdit;
            var txtMailboxAlias = this.Controls.Find("txtMailboxAlias", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var memDescription = this.Controls.Find("memDescription", true).FirstOrDefault() as DevExpress.XtraEditors.MemoEdit;

            if (txtCode != null) txtCode.Text = entity.Code;
            if (txtTitle != null) txtTitle.Text = entity.Title;
            if (txtShortCode != null) txtShortCode.Text = entity.ShortCode;
            if (tglActive != null) tglActive.IsOn = entity.IsActive;

            if (cmbCardType != null) cmbCardType.SelectedItem = WinBeyazEsya.Domain.Helpers.EnumFunctions.GetDescription((CardType)(entity.CardType > 0 ? entity.CardType : 1));
            if (glufSpecialCode != null) glufSpecialCode.EditValue = entity.SpeCode;
            if (txtAuthorizedPerson != null) txtAuthorizedPerson.Text = entity.InCharge;
            if (memAddress != null) memAddress.Text = entity.Addr1;
            if (txtPhone1 != null) txtPhone1.Text = entity.TelNrs1;
            if (txtPhone2 != null) txtPhone2.Text = entity.TelNrs2;
            if (txtMobilePhone != null) txtMobilePhone.Text = entity.CellPhone;
            if (txtEmail != null) txtEmail.Text = entity.EmailAddr;
            if (txtWebAddress != null) txtWebAddress.Text = entity.WebAddr;
            if (txtTaxOffice != null) txtTaxOffice.Text = entity.TaxOffice;
            if (txtTaxNumber != null) txtTaxNumber.Text = entity.TaxNr;

            if (cmbCurrencyId != null) cmbCurrencyId.SelectedItem = WinBeyazEsya.Domain.Helpers.EnumFunctions.GetDescription((WinBeyazEsya.Domain.Enums.CurrencyType)(entity.CCurrency > 0 ? entity.CCurrency : 160));
            if (cmbPaymentType != null) cmbPaymentType.SelectedItem = WinBeyazEsya.Domain.Helpers.EnumFunctions.GetDescription((WinBeyazEsya.Domain.Enums.PaymentType)(entity.PaymentType > 0 ? entity.PaymentType : 1));
            if (spnMaturityDays != null) spnMaturityDays.Value = entity.MaturityDays;
            if (chkIsEInvoiceUser != null) chkIsEInvoiceUser.Checked = entity.IsEInvoiceUser;
            if (chkIsEDispatchUser != null) chkIsEDispatchUser.Checked = entity.IsEDispatchUser;
            if (txtMailboxAlias != null) txtMailboxAlias.Text = entity.MailboxAlias;
            if (memDescription != null) memDescription.Text = entity.Description;

            if (glufCountry != null && entity.CountryId.HasValue) glufCountry.EditValue = entity.CountryId;
            if (glufCity != null && entity.CityId.HasValue) glufCity.EditValue = entity.CityId;
            if (glufTown != null && entity.TownId.HasValue) glufTown.EditValue = entity.TownId;

            if (BaseIslemTuru == ActionType.EntityInsert && txtCode != null)
            {
                txtCode.Text = "Yeni Kod";
            }
        }

        protected override void GuncelNesneOlustur()
        {
            var txtCode = this.Controls.Find("txtCode", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var txtTitle = this.Controls.Find("txtTitle", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var txtShortCode = this.Controls.Find("txtShortCode", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var tglActive = this.Controls.Find("tgsIsActive", true).FirstOrDefault() as DevExpress.XtraEditors.ToggleSwitch;
            var cmbCardType = this.Controls.Find("cmbCardType", true).FirstOrDefault() as DevExpress.XtraEditors.ComboBoxEdit;
            var glufSpecialCode = this.Controls.Find("glufSpecialCode", true).FirstOrDefault() as DevExpress.XtraEditors.GridLookUpEdit;
            var txtAuthorizedPerson = this.Controls.Find("txtAuthorizedPerson", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var glufCountry = this.Controls.Find("glufCountry", true).FirstOrDefault() as DevExpress.XtraEditors.GridLookUpEdit;
            var glufCity = this.Controls.Find("glufCity", true).FirstOrDefault() as DevExpress.XtraEditors.GridLookUpEdit;
            var glufTown = this.Controls.Find("glufTown", true).FirstOrDefault() as DevExpress.XtraEditors.GridLookUpEdit;
            var memAddress = this.Controls.Find("memAddress", true).FirstOrDefault() as DevExpress.XtraEditors.MemoEdit;
            var txtPhone1 = this.Controls.Find("txtPhone1", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var txtPhone2 = this.Controls.Find("txtPhone2", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var txtMobilePhone = this.Controls.Find("txtMobilePhone", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var txtEmail = this.Controls.Find("txtEmail", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var txtWebAddress = this.Controls.Find("txtWebAddress", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var txtTaxOffice = this.Controls.Find("txtTaxOffice", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var txtTaxNumber = this.Controls.Find("txtTaxNumber", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;

            var cmbCurrencyId = this.Controls.Find("cmbCurrencyId", true).FirstOrDefault() as DevExpress.XtraEditors.ComboBoxEdit;
            var cmbPaymentType = this.Controls.Find("cmbPaymentType", true).FirstOrDefault() as DevExpress.XtraEditors.ComboBoxEdit;
            var spnMaturityDays = this.Controls.Find("spnMaturityDays", true).FirstOrDefault() as DevExpress.XtraEditors.SpinEdit;
            var chkIsEInvoiceUser = this.Controls.Find("chkIsEInvoiceUser", true).FirstOrDefault() as DevExpress.XtraEditors.CheckEdit;
            var chkIsEDispatchUser = this.Controls.Find("chkIsEDispatchUser", true).FirstOrDefault() as DevExpress.XtraEditors.CheckEdit;
            var txtMailboxAlias = this.Controls.Find("txtMailboxAlias", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var memDescription = this.Controls.Find("memDescription", true).FirstOrDefault() as DevExpress.XtraEditors.MemoEdit;

            CurrentEntity = new CurrentAccountDto
            {
                Id = Id,
                Code = txtCode?.Text,
                Title = txtTitle?.Text,
                ShortCode = txtShortCode?.Text,
                IsActive = tglActive?.IsOn ?? true,
                Active = (tglActive?.IsOn ?? true) ? 1 : 0,
                CardType = cmbCardType?.SelectedItem != null ? (int)WinBeyazEsya.Domain.Helpers.EnumFunctions.GetEnum<CardType>(cmbCardType.SelectedItem.ToString()) : 0,
                SpeCode = glufSpecialCode?.EditValue?.ToString(),
                InCharge = txtAuthorizedPerson?.Text,
                CountryId = glufCountry?.EditValue != null && long.TryParse(glufCountry.EditValue.ToString(), out long cid) ? cid : null,
                CityId = glufCity?.EditValue != null && long.TryParse(glufCity.EditValue.ToString(), out long ctyid) ? ctyid : null,
                TownId = glufTown?.EditValue != null && long.TryParse(glufTown.EditValue.ToString(), out long twnid) ? twnid : null,
                Addr1 = memAddress?.Text,
                TelNrs1 = txtPhone1?.Text,
                TelNrs2 = txtPhone2?.Text,
                CellPhone = txtMobilePhone?.Text,
                EmailAddr = txtEmail?.Text,
                WebAddr = txtWebAddress?.Text,
                TaxOffice = txtTaxOffice?.Text,
                TaxNr = txtTaxNumber?.Text,
                CCurrency = cmbCurrencyId?.SelectedItem != null ? (int)WinBeyazEsya.Domain.Helpers.EnumFunctions.GetEnum<WinBeyazEsya.Domain.Enums.CurrencyType>(cmbCurrencyId.SelectedItem.ToString()) : 0,
                PaymentType = cmbPaymentType?.SelectedItem != null ? (int)WinBeyazEsya.Domain.Helpers.EnumFunctions.GetEnum<WinBeyazEsya.Domain.Enums.PaymentType>(cmbPaymentType.SelectedItem.ToString()) : 0,
                MaturityDays = spnMaturityDays != null ? Convert.ToInt32(spnMaturityDays.Value) : 0,
                IsEInvoiceUser = chkIsEInvoiceUser?.Checked ?? false,
                IsEDispatchUser = chkIsEDispatchUser?.Checked ?? false,
                MailboxAlias = txtMailboxAlias?.Text,
                Description = memDescription?.Text
            };
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            try
            {
                var dto = (CurrentAccountDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);
                Id = _currentAccountService.Insert(dto);
                return Id > 0;
            }
            catch (Exception ex)
            {
                Messages.HataBasligi(ex.Message, "Kayıt Hatası");
                return false;
            }
        }

        protected override bool EntityUpdate()
        {
            try
            {
                _currentAccountService.Update((CurrentAccountDto)CurrentEntity);
                return true;
            }
            catch (Exception ex)
            {
                Messages.HataBasligi(ex.Message, "Güncelleme Hatası");
                return false;
            }
        }
    }
}