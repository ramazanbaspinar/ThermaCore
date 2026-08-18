using System.Data.SqlClient;
using WinBeyazEsya.Application.Interfaces.Integration;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.GenelForms
{
    public partial class DisSistemEntegrasyonEditForm : BaseEditForm
    {
        private readonly IIntegrationService _integrationService;

        public DisSistemEntegrasyonEditForm(IIntegrationService integrationService)
        {
            InitializeComponent();
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.GenelParametreler;
            _integrationService = integrationService;

            // Load ComboBox items
            cmbEntegrasyonTipi.Properties.Items.Clear();
            cmbEntegrasyonTipi.Properties.Items.Add("Logo ERP (Tiger/Go3)");
            cmbEntegrasyonTipi.Properties.Items.Add("Özel Sorgu");
            cmbEntegrasyonTipi.SelectedIndex = 0;

            // Hide default buttons
            if (btnYeni != null) btnYeni.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (btnKaydet != null) btnKaydet.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (btnGerial != null) btnGerial.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (btnSil != null) btnSil.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            // Event Subscriptions
            btnBaglantiTestEt.Click += BtnBaglantiTestEt_Click;
            btnAktarimiBaslat.Click += BtnTamaminiAktar_Click;

            txtFirmaNo.EditValueChanged += TxtFirmaNo_EditValueChanged;
            cmbEntegrasyonTipi.SelectedIndexChanged += CmbEntegrasyonTipi_SelectedIndexChanged;

            // Set default view
            GuncelleSorguOnizleme();
        }

        private void CmbEntegrasyonTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            GuncelleSorguOnizleme();
        }

        private void TxtFirmaNo_EditValueChanged(object sender, EventArgs e)
        {
            GuncelleSorguOnizleme();
        }

        private void GuncelleSorguOnizleme()
        {
            string firmaNo = txtFirmaNo.Text;
            string paddedFirmaNo = (string.IsNullOrWhiteSpace(firmaNo) ? "001" : firmaNo).PadLeft(3, '0');
            int entType = cmbEntegrasyonTipi.SelectedIndex;

            if (entType == 0) // Logo
            {
                memoGonderilecekSorgu.Text =
                        $"-- CARİ KARTLAR SORGUSU --\r\n" +
                        $"SELECT LOGICALREF, CODE, DEFINITION_ as TITLE, ACTIVE, TAXNR, TAXOFFICE, COUNTRY, TOWN, CITY, TELNRS1, TELNRS2, CELLPHONE\r\n" +
                        $"FROM LG_{paddedFirmaNo}_CLCARD WHERE CARDTYPE = 3\r\n\r\n" +
                        $"-- ÜLKELER SORGUSU --\r\n" +
                        $"SELECT LOGICALREF, CODE, NAME FROM L_COUNTRY\r\n\r\n" +
                        $"-- İLLER SORGUSU --\r\n" +
                        $"SELECT LOGICALREF, CODE, NAME FROM L_CITY\r\n\r\n" +
                        $"-- İLÇELER SORGUSU --\r\n" +
                        $"SELECT LOGICALREF, CODE, NAME FROM L_TOWN";
            }
            else // Özel
            {
                memoGonderilecekSorgu.Text = "-- ÖZEL SORGULAR KULLANILACAK --\r\n\r\nLütfen Aktarım tipine göre kendi özel sorgularınızı arka planda tanımlayınız veya memoOzelSorgu alanını kullanınız.\r\n" +
                                             memoOzelSorgu.Text;
            }
        }

        private async void BtnBaglantiTestEt_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var builder = new SqlConnectionStringBuilder
                {
                    DataSource = txtKaynakSunucuIp.Text,
                    InitialCatalog = txtKaynakVeritabani.Text,
                    UserID = txtKullaniciAdi.Text,
                    Password = txtSifre.Text,
                    TrustServerCertificate = true
                };

                using var conn = new SqlConnection(builder.ConnectionString);
                await conn.OpenAsync();

                Messages.BilgiMesaji("Bağlantı Başarılı!");
            }
            catch (Exception ex)
            {
                Messages.HataMesaji("Bağlantı Hatası: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


        private async void BtnTamaminiAktar_Click(object sender, EventArgs e)
        {
            if (_integrationService == null) return;
            try
            {
                btnAktarimiBaslat.Enabled = false;
                btnBaglantiTestEt.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;

                var res1 = await _integrationService.SyncCountriesAsync(
                    txtKaynakSunucuIp.Text, txtKaynakVeritabani.Text, txtKullaniciAdi.Text, txtSifre.Text,
                    cmbEntegrasyonTipi.SelectedIndex, memoOzelSorgu.Text);

                var res2 = await _integrationService.SyncCitiesAsync(
                    txtKaynakSunucuIp.Text, txtKaynakVeritabani.Text, txtKullaniciAdi.Text, txtSifre.Text,
                    cmbEntegrasyonTipi.SelectedIndex, memoOzelSorgu.Text);

                var res3 = await _integrationService.SyncTownsAsync(
                    txtKaynakSunucuIp.Text, txtKaynakVeritabani.Text, txtKullaniciAdi.Text, txtSifre.Text,
                    cmbEntegrasyonTipi.SelectedIndex, memoOzelSorgu.Text);

                var res4 = await _integrationService.SyncCurrentAccountsAsync(
                    txtKaynakSunucuIp.Text, txtKaynakVeritabani.Text, txtKullaniciAdi.Text, txtSifre.Text, txtFirmaNo.Text,
                    cmbEntegrasyonTipi.SelectedIndex, memoOzelSorgu.Text);

                int totalAdded = res1.AddedCount + res2.AddedCount + res3.AddedCount + res4.AddedCount;
                int totalUpdated = res1.UpdatedCount + res2.UpdatedCount + res3.UpdatedCount + res4.UpdatedCount;
                int totalSkipped = res1.SkippedCount + res2.SkippedCount + res3.SkippedCount + res4.SkippedCount;
                int totalMissing = res1.MissingReferenceCount + res2.MissingReferenceCount + res3.MissingReferenceCount + res4.MissingReferenceCount;
                int totalError = res1.ErrorCount + res2.ErrorCount + res3.ErrorCount + res4.ErrorCount;
                int totalProcessed = totalAdded + totalUpdated + totalSkipped + totalMissing + totalError;

                string resultMsg = $"Aktarım İşlemi Tamamlandı!\n\n" +
                                   $"• Toplam Değerlendirilen Kayıt: {totalProcessed}\n" +
                                   $"• Yeni Eklenen: {totalAdded}\n" +
                                   $"• Güncellenen: {totalUpdated}\n" +
                                   $"• Referans Eksikliği Nedeniyle Aktarılmayan: {totalMissing}\n" +
                                   $"• Değişiklik Olmadığı İçin Es Geçilen: {totalSkipped}\n" +
                                   $"• Hata: {totalError}";

                Messages.BilgiMesaji(resultMsg);
            }
            catch (Exception ex)
            {
                Messages.HataMesaji(ex.Message);
            }
            finally
            {
                btnAktarimiBaslat.Enabled = true;
                btnBaglantiTestEt.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }
    }
}