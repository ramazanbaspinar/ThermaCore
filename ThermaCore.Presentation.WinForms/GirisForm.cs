#pragma warning disable CS8618
using System;
using System.Windows.Forms;
using ThermaCore.Application.Interfaces.Configuration;
using ThermaCore.Application.Services.Yonetim;

namespace ThermaCore.Presentation.WinForms;

public partial class GirisForm : Form
{
    private readonly IKullaniciService _kullaniciService;
    private readonly IAppConfigService _appConfigService;

    // UI Skeleton Kontrolleri
    private TextBox txtKullaniciKodu;
    private TextBox txtSifre;
    private Button btnGiris;
    private Label lblKullanici;
    private Label lblSifre;

    public GirisForm(IKullaniciService kullaniciService, IAppConfigService appConfigService)
    {
        _kullaniciService = kullaniciService;
        _appConfigService = appConfigService;

        InitializeSkeletonControls();
        this.Load += GirisForm_Load;
    }

    private void InitializeSkeletonControls()
    {
        this.Text = "ThermaCore - Kullanıcı Girişi";
        this.Width = 350;
        this.Height = 250;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;

        lblKullanici = new Label { Left = 40, Top = 30, Width = 100, Text = "Kullanıcı Kodu:" };
        txtKullaniciKodu = new TextBox { Left = 140, Top = 27, Width = 150 };
        
        lblSifre = new Label { Left = 40, Top = 70, Width = 100, Text = "Şifre:" };
        txtSifre = new TextBox { Left = 140, Top = 67, Width = 150, PasswordChar = '*' };
        
        btnGiris = new Button { Left = 140, Top = 120, Width = 150, Text = "Giriş Yap", Height = 40 };
        btnGiris.Click += BtnGiris_Click;

        this.Controls.Add(lblKullanici);
        this.Controls.Add(txtKullaniciKodu);
        this.Controls.Add(lblSifre);
        this.Controls.Add(txtSifre);
        this.Controls.Add(btnGiris);
        
        this.AcceptButton = btnGiris;
    }

    private void GirisForm_Load(object? sender, EventArgs e)
    {
        // Eski sistemden gelen: Son giren kullanıcıyı getir
        string lastUser = _appConfigService.GetLastLoginUser();
        if (!string.IsNullOrEmpty(lastUser))
        {
            txtKullaniciKodu.Text = lastUser;
            txtSifre.Focus();
        }
    }

    private void BtnGiris_Click(object? sender, EventArgs e)
    {
        string kod = txtKullaniciKodu.Text;
        string sifre = txtSifre.Text;

        if (string.IsNullOrWhiteSpace(kod) || string.IsNullOrWhiteSpace(sifre))
        {
            MessageBox.Show("Kullanıcı kodu ve şifre boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var kullanici = _kullaniciService.KullaniciGirisYap(kod, sifre);

        if (kullanici != null)
        {
            _appConfigService.SetLastLoginUser(kod); // Başarılı girişte ayarı kaydet
            MessageBox.Show($"Hoşgeldiniz {kullanici.Adi} {kullanici.Soyadi}!\nThermaCore Sistemine Giriş Yapıldı.", "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // İleride MainForm'a yönlendirme kodları buraya yazılacak.
        }
        else
        {
            MessageBox.Show("Kullanıcı kodu veya şifre hatalı!", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
