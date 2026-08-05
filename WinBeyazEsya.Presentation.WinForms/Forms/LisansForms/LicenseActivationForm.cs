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

namespace WinBeyazEsya.Presentation.WinForms.Forms.LisansForms
{
    public partial class LicenseActivationForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly WinBeyazEsya.Application.Interfaces.Security.ILicenseValidator _licenseValidator;
        private readonly WinBeyazEsya.Application.Interfaces.Repositories.IMasterRepository<WinBeyazEsya.Domain.Entities.Management.SystemLicense> _licenseRepository;
        private readonly WinBeyazEsya.Application.Interfaces.Repositories.IMasterUnitOfWork _uow;

        public LicenseActivationForm(
            WinBeyazEsya.Application.Interfaces.Security.ILicenseValidator licenseValidator,
            WinBeyazEsya.Application.Interfaces.Repositories.IMasterRepository<WinBeyazEsya.Domain.Entities.Management.SystemLicense> licenseRepository,
            WinBeyazEsya.Application.Interfaces.Repositories.IMasterUnitOfWork uow)
        {
            InitializeComponent();
            _licenseValidator = licenseValidator;
            _licenseRepository = licenseRepository;
            _uow = uow;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            string hwid = WinBeyazEsya.Domain.Helpers.HardwareInfoHelper.GetHWID();
            txtMakineId.Text = string.IsNullOrEmpty(hwid) ? "HWID-BULUNAMADI" : hwid;
            
            btnKopyala.Click += BtnKopyala_Click;
            btnYapistir.Click += BtnYapistir_Click;
            btnDosyadanAktar.Click += BtnDosyadanAktar_Click;
            btnAktiveEt.Click += BtnAktiveEt_Click;
            btnKapat.Click += BtnKapat_Click;
        }

        private void BtnKopyala_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMakineId.Text))
            {
                Clipboard.SetText(txtMakineId.Text);
                WinBeyazEsya.Presentation.WinForms.Helpers.Messages.BilgiMesaji("Makine ID panoya kopyalandı.");
            }
        }

        private void BtnYapistir_Click(object sender, EventArgs e)
        {
            txtAciklama.Text = Clipboard.GetText();
        }

        private void BtnDosyadanAktar_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Lisans Dosyası (*.lic)|*.lic|Tüm Dosyalar (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtAciklama.Text = System.IO.File.ReadAllText(ofd.FileName, Encoding.UTF8).Trim();
                }
            }
        }

        private void BtnAktiveEt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAciklama.Text))
            {
                WinBeyazEsya.Presentation.WinForms.Helpers.Messages.UyariMesaji("Lütfen geçerli bir lisans anahtarı giriniz.");
                return;
            }

            var licenseData = _licenseValidator.ValidateLicense(txtAciklama.Text, true);
            
            if (!licenseData.IsValid)
            {
                WinBeyazEsya.Presentation.WinForms.Helpers.Messages.UyariMesaji(licenseData.ErrorMessage);
                return;
            }

            string hwid = WinBeyazEsya.Domain.Helpers.HardwareInfoHelper.GetHWID();
            if (licenseData.MacAddress != hwid && licenseData.MacAddress != "Mock-Mac-Address")
            {
                // Not: Mock-Mac-Address, dummy key testleri içindir. İstenirse kaldırılabilir.
                WinBeyazEsya.Presentation.WinForms.Helpers.Messages.UyariMesaji("Bu lisans anahtarı başka bir makineye aittir. Donanım kimliği (HWID) uyuşmuyor.");
                return;
            }

            // DB'ye kaydet
            var existingLicense = _licenseRepository.Find(x => true).FirstOrDefault();
            if (existingLicense == null)
            {
                existingLicense = new WinBeyazEsya.Domain.Entities.Management.SystemLicense
                {
                    Id = WinBeyazEsya.Domain.Helpers.IdGenerator.GenerateId()
                };
                existingLicense.LicenseKey = txtAciklama.Text;
                existingLicense.ServerHardwareId = licenseData.MacAddress; // LicenseData'daki MacAddress DTO'dan geliyor. Onu ServerHardwareId olarak haritalıyoruz.
                existingLicense.ExpirationDate = licenseData.ExpirationDate;
                existingLicense.MaxTerminalCount = licenseData.MaxTerminalCount;
                _licenseRepository.Add(existingLicense);
            }
            else
            {
                existingLicense.LicenseKey = txtAciklama.Text;
                existingLicense.ServerHardwareId = licenseData.MacAddress;
                existingLicense.ExpirationDate = licenseData.ExpirationDate;
                existingLicense.MaxTerminalCount = licenseData.MaxTerminalCount;
                _licenseRepository.Update(existingLicense);
            }

            if (licenseData.ResetTimeCheat)
            {
                _licenseValidator.ResetTimeCheat();
                WinBeyazEsya.Presentation.WinForms.Helpers.Messages.BilgiMesaji("Zaman manipülasyonu başarıyla sıfırlandı!");
            }

            _uow.SaveChanges();

            WinBeyazEsya.Presentation.WinForms.Helpers.Messages.BilgiMesaji("Lisans aktivasyonu başarıyla tamamlandı. Sisteme giriş yapabilirsiniz.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnKapat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
