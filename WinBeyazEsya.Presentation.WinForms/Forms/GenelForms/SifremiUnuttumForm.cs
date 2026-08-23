using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Application.Interfaces.Mailing;
using WinBeyazEsya.Application.Interfaces.Management;

namespace WinBeyazEsya.Presentation.WinForms.Forms.GenelForms
{
    public partial class SifremiUnuttumForm : XtraForm
    {
        private readonly IUserService _userService;
        private readonly IMailService _mailService;

        private string _currentOtp;
        private DateTime _otpExpirationTime;
        private UserDto _currentUser;

        public SifremiUnuttumForm(IUserService userService, IMailService mailService)
        {
            InitializeComponent();
            _userService = userService;
            _mailService = mailService;
        }

        private void btnKodGonder_Click(object sender, EventArgs e)
        {
            string username = txtKullaniciAdi.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                XtraMessageBox.Show("Lütfen kullanıcı adınızı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kullanıcıyı bul
                var userList = _userService.GetAll();
                _currentUser = userList.FirstOrDefault(x => x.Code.Equals(username, StringComparison.OrdinalIgnoreCase));

                if (_currentUser == null)
                {
                    XtraMessageBox.Show("Belirtilen kullanıcı adı sistemde bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(_currentUser.Email))
                {
                    XtraMessageBox.Show("Kullanıcıya tanımlı bir e-posta adresi bulunmuyor. Lütfen sistem yöneticisi ile iletişime geçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // E-Postayı maskele (Örn: a***@gmail.com)
                string maskedEmail = MaskEmail(_currentUser.Email);

                // 6 haneli OTP üret
                _currentOtp = new Random().Next(100000, 999999).ToString();
                _otpExpirationTime = DateTime.Now.AddMinutes(3); // 3 dakika geçerli

                // Mail gönder
                _mailService.SendPasswordResetMail(_currentUser.Email, _currentOtp);

                // Arayüzü 2. aşamaya geçir
                grpSifirlama.Visibility = LayoutVisibility.Always;
                lblBilgiMesaji.Text = $"Doğrulama kodunuz {maskedEmail} adresine gönderildi.";
                lblBilgiMesaji.Visible = true;
                txtDogrulamaKodu.Visible = true;
                txtYeniParola.Visible = true;
                txtYeniParolaTekrar.Visible = true;

                btnSifreGuncelle.Visible = true;
                btnKodGonder.Visible = false; // Artık tekrar basamasın veya istersen Enabled = false yap

                txtKullaniciAdi.Enabled = false; // Kullanıcı adını değiştirmesin
                txtDogrulamaKodu.Focus();

                this.AcceptButton = btnSifreGuncelle;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Kod gönderilirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSifreGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDogrulamaKodu.Text) || string.IsNullOrEmpty(txtYeniParola.Text))
            {
                XtraMessageBox.Show("Lütfen doğrulama kodunu ve yeni parolanızı eksiksiz giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtDogrulamaKodu.Text != _currentOtp)
            {
                XtraMessageBox.Show("Girdiğiniz doğrulama kodu hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DateTime.Now > _otpExpirationTime)
            {
                XtraMessageBox.Show("Doğrulama kodunun süresi dolmuş (3 dakika). Lütfen işlemi baştan başlatın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtYeniParola.Text != txtYeniParolaTekrar.Text)
            {
                XtraMessageBox.Show("Girdiğiniz parolalar eşleşmiyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var fullUser = _userService.GetById(_currentUser.Id);
                fullUser.Password = txtYeniParola.Text;
                _userService.Update(fullUser);

                XtraMessageBox.Show("Parolanız başarıyla güncellendi. Yeni parolanızla giriş yapabilirsiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Parola güncellenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private string MaskEmail(string email)
        {
            var parts = email.Split('@');
            if (parts.Length != 2) return email;

            string name = parts[0];
            string domain = parts[1];

            if (name.Length <= 2)
            {
                name = name.Substring(0, 1) + "***";
            }
            else
            {
                name = name.Substring(0, 1) + new string('*', name.Length - 2) + name.Substring(name.Length - 1, 1);
            }

            return $"{name}@{domain}";
        }
    }
}
