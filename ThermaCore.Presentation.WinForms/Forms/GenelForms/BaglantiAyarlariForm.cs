#pragma warning disable CS8618
using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ThermaCore.Application.Interfaces.Configuration;

namespace ThermaCore.Presentation.WinForms.Forms.GenelForms;

public partial class BaglantiAyarlariForm : Form
{
    private readonly IAppConfigService _configService;
    
    private TextBox txtSunucu;
    private ComboBox cmbYetkilendirme;
    private TextBox txtKullanici;
    private TextBox txtSifre;
    private Button btnTest;
    private Button btnKaydet;

    public BaglantiAyarlariForm(IAppConfigService configService)
    {
        _configService = configService;
        InitializeSkeletonControls();
    }

    private void InitializeSkeletonControls()
    {
        this.Text = "ThermaCore - Veritabanı Bağlantı Ayarları";
        this.Width = 400;
        this.Height = 300;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;

        Label lblSunucu = new Label { Left = 30, Top = 30, Width = 120, Text = "Sunucu Adresi:" };
        txtSunucu = new TextBox { Left = 160, Top = 27, Width = 180, Text = "localhost" };

        Label lblYetkilendirme = new Label { Left = 30, Top = 70, Width = 120, Text = "Yetkilendirme:" };
        cmbYetkilendirme = new ComboBox { Left = 160, Top = 67, Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };
        cmbYetkilendirme.Items.AddRange(new object[] { "Windows Authentication", "SQL Server Authentication" });
        cmbYetkilendirme.SelectedIndex = 0;
        cmbYetkilendirme.SelectedIndexChanged += (s, e) => 
        {
            bool isSqlAuth = cmbYetkilendirme.SelectedIndex == 1;
            txtKullanici.Enabled = isSqlAuth;
            txtSifre.Enabled = isSqlAuth;
        };

        Label lblKullanici = new Label { Left = 30, Top = 110, Width = 120, Text = "Kullanıcı Adı:" };
        txtKullanici = new TextBox { Left = 160, Top = 107, Width = 180, Enabled = false };

        Label lblSifre = new Label { Left = 30, Top = 150, Width = 120, Text = "Şifre:" };
        txtSifre = new TextBox { Left = 160, Top = 147, Width = 180, PasswordChar = '*', Enabled = false };

        btnTest = new Button { Left = 160, Top = 190, Width = 85, Text = "Test Et" };
        btnTest.Click += BtnTest_Click;

        btnKaydet = new Button { Left = 255, Top = 190, Width = 85, Text = "Kaydet" };
        btnKaydet.Click += BtnKaydet_Click;

        this.Controls.Add(lblSunucu); this.Controls.Add(txtSunucu);
        this.Controls.Add(lblYetkilendirme); this.Controls.Add(cmbYetkilendirme);
        this.Controls.Add(lblKullanici); this.Controls.Add(txtKullanici);
        this.Controls.Add(lblSifre); this.Controls.Add(txtSifre);
        this.Controls.Add(btnTest); this.Controls.Add(btnKaydet);
    }

    private string BuildConnectionString()
    {
        var builder = new SqlConnectionStringBuilder
        {
            DataSource = txtSunucu.Text,
            InitialCatalog = "ThermaCoreDb",
            TrustServerCertificate = true,
            Encrypt = false
        };

        if (cmbYetkilendirme.SelectedIndex == 0) // Windows
        {
            builder.IntegratedSecurity = true;
        }
        else // SQL Server
        {
            builder.IntegratedSecurity = false;
            builder.UserID = txtKullanici.Text;
            builder.Password = txtSifre.Text;
        }

        return builder.ConnectionString;
    }

    private void BtnTest_Click(object? sender, EventArgs e)
    {
        string connStr = BuildConnectionString();
        try
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                MessageBox.Show("Bağlantı başarılı!", "Bağlantı Testi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Bağlantı hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnKaydet_Click(object? sender, EventArgs e)
    {
        string connStr = BuildConnectionString();
        try
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
            }
            
            _configService.SetConnectionString(connStr);
            MessageBox.Show("Bağlantı ayarları başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Bağlantı doğrulanamadı. Lütfen ayarları kontrol edin: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
