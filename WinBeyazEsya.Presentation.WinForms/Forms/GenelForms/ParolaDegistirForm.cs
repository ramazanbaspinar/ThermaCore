using DevExpress.XtraEditors;
using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Application.Interfaces.Management;
using WinBeyazEsya.Domain.Helpers;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.GenelForms
{
    public partial class ParolaDegistirForm : XtraForm
    {
        private readonly IUserService _userService;
        private readonly long _currentUserId;

        public ParolaDegistirForm(IUserService userService, long currentUserId)
        {
            InitializeComponent();
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _currentUserId = currentUserId;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Kural 1: Boş alan kontrolü
            if (string.IsNullOrWhiteSpace(txtEskiParola.Text) ||
                string.IsNullOrWhiteSpace(txtYeniParola.Text) ||
                string.IsNullOrWhiteSpace(txtYeniParolaTekrar.Text))
            {
                Messages.UyariMesaji("Lütfen tüm parola alanlarını eksiksiz doldurunuz.");
                return;
            }

            // Kural 2: Yeni parolaların eşleşmesi
            if (txtYeniParola.Text != txtYeniParolaTekrar.Text)
            {
                Messages.HataMesaji("Girdiğiniz yeni parolalar birbiriyle uyuşmuyor!");
                txtYeniParola.Focus();
                return;
            }

            // Kural 3: Yeni parola eskisi ile aynı olamaz
            if (txtEskiParola.Text == txtYeniParola.Text)
            {
                Messages.UyariMesaji("Yeni parolanız eski parolanızla aynı olamaz. Lütfen farklı bir parola giriniz.");
                txtYeniParola.Focus();
                return;
            }

            try
            {
                // Mevcut kullanıcıyı veritabanından çek (DTO)
                UserDto userDto = _userService.GetById(_currentUserId);
                if (userDto == null)
                {
                    Messages.HataMesaji("Kullanıcı bilgisine ulaşılamadı. Lütfen yeniden giriş yapınız.");
                    return;
                }

                // Eski parolayı doğrula
                bool isValid = false;

                // DTO içerisindeki Hash ve Salt mevcutsa (UserDto'ya eklendiyse) doğrudan PasswordHasher kullanılır.
                if (userDto.PasswordHash != null && userDto.PasswordSalt != null && userDto.PasswordHash.Length > 0)
                {
                    isValid = PasswordHasher.VerifyPasswordHash(txtEskiParola.Text, userDto.PasswordHash, userDto.PasswordSalt);
                }
                else
                {
                    // Eğer DTO, Hash/Salt taşımıyorsa, mevcut mimari kuralları gereği doğrulama için servise başvurulur.
                    try
                    {
                        _userService.UserLogin(userDto.Code, txtEskiParola.Text);
                        isValid = true;
                    }
                    catch
                    {
                        isValid = false;
                    }
                }

                if (!isValid)
                {
                    Messages.HataMesaji("Mevcut parolanızı yanlış girdiniz. Lütfen tekrar deneyiniz.");
                    txtEskiParola.Focus();
                    return;
                }

                // Yeni şifreyi PasswordHasher ile oluşturup atama
                PasswordHasher.CreatePasswordHash(txtYeniParola.Text, out byte[] newHash, out byte[] newSalt);

                userDto.PasswordHash = newHash;
                userDto.PasswordSalt = newSalt;

                // Ayrıca UserManager.Update metodunun şifrelemeyi yeniden tetiklemesi veya kontrol etmesi durumuna 
                // karşılık düz metni de set ediyoruz.
                userDto.Password = txtYeniParola.Text;

                // Veritabanına kaydet
                _userService.Update(userDto);

                Messages.BilgiMesaji("Parolanız başarıyla güncellenmiştir.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Messages.HataMesaji($"Parola değiştirme işlemi sırasında bir hata oluştu:\n{ex.Message}");
            }
        }
    }
}
