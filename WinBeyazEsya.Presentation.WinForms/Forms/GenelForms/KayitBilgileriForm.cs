using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace WinBeyazEsya.Presentation.WinForms.Forms.GenelForms
{
    public class KayitBilgileriForm : XtraForm
    {
        private readonly string _ekleyenUser;
        private readonly DateTime? _eklemeTarihi;
        private readonly string _degistirenUser;
        private readonly DateTime? _degistirmeTarihi;

        private static readonly CultureInfo TrCulture = new CultureInfo("tr-TR");

        public KayitBilgileriForm(string ekleyenUser, DateTime? eklemeTarihi, string degistirenUser, DateTime? degistirmeTarihi)
        {
            _ekleyenUser = ekleyenUser;
            _eklemeTarihi = eklemeTarihi;
            _degistirenUser = degistirenUser;
            _degistirmeTarihi = degistirmeTarihi;

            InitializeFormLayout();
        }

        private void InitializeFormLayout()
        {
            // Form ayarları
            this.Text = "Kayıt Bilgileri";
            this.Size = new Size(420, 210);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.IconOptions.ShowIcon = false;

            // Ana panel
            var mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(16, 12, 16, 8)
            };

            // === SOL SÜTUN: Ekleyen ===
            int solX = 16;
            int sagX = 210;
            int currentY = 12;

            // Ekleyen başlık
            var lblEkleyenBaslik = CreateHeaderLabel("Ekleyen", solX, currentY);
            mainPanel.Controls.Add(lblEkleyenBaslik);

            // Son Değiştiren başlık
            var lblDegistirenBaslik = CreateHeaderLabel("Son Değiştiren", sagX, currentY);
            mainPanel.Controls.Add(lblDegistirenBaslik);

            // Ayırıcı çizgi
            currentY += 22;
            var separator = new Panel
            {
                Location = new Point(solX, currentY),
                Size = new Size(372, 1),
                BackColor = Color.LightGray
            };
            mainPanel.Controls.Add(separator);
            currentY += 8;

            // Ekleyen kullanıcı adı
            var lblEkleyenUser = CreateValueLabel(_ekleyenUser ?? "", solX, currentY, true);
            mainPanel.Controls.Add(lblEkleyenUser);

            // Değiştiren kullanıcı adı
            var lblDegistirenUser = CreateValueLabel(_degistirenUser ?? "", sagX, currentY, true);
            mainPanel.Controls.Add(lblDegistirenUser);

            currentY += 20;

            // Ekleyen tarih
            string eklemeTarihStr = _eklemeTarihi.HasValue
                ? _eklemeTarihi.Value.ToString("dd.MMMM.yyyy.dddd", TrCulture)
                : "";
            var lblEklemeTarih = CreateValueLabel(eklemeTarihStr, solX, currentY, false);
            mainPanel.Controls.Add(lblEklemeTarih);

            // Değiştiren tarih
            string degistirmeTarihStr = _degistirmeTarihi.HasValue
                ? _degistirmeTarihi.Value.ToString("dd.MMMM.yyyy.dddd", TrCulture)
                : "";
            var lblDegistirmeTarih = CreateValueLabel(degistirmeTarihStr, sagX, currentY, false);
            mainPanel.Controls.Add(lblDegistirmeTarih);

            currentY += 18;

            // Ekleyen saat
            string eklemeSaatStr = _eklemeTarihi.HasValue
                ? _eklemeTarihi.Value.ToString("HH:mm:ss.fff", TrCulture)
                : "";
            var lblEklemeSaat = CreateValueLabel(eklemeSaatStr, solX, currentY, false);
            mainPanel.Controls.Add(lblEklemeSaat);

            // Değiştiren saat
            string degistirmeSaatStr = _degistirmeTarihi.HasValue
                ? _degistirmeTarihi.Value.ToString("HH:mm:ss.fff", TrCulture)
                : "";
            var lblDegistirmeSaat = CreateValueLabel(degistirmeSaatStr, sagX, currentY, false);
            mainPanel.Controls.Add(lblDegistirmeSaat);

            this.Controls.Add(mainPanel);

            // === KAPAT BUTONU ===
            var btnKapat = new SimpleButton
            {
                Text = "Kapat",
                Size = new Size(80, 28),
                DialogResult = DialogResult.Cancel,
                TabIndex = 0
            };
            btnKapat.Location = new Point(this.ClientSize.Width - btnKapat.Width - 16, this.ClientSize.Height - btnKapat.Height - 10);
            btnKapat.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.Controls.Add(btnKapat);

            this.CancelButton = btnKapat;
            this.AcceptButton = btnKapat;
        }

        private static LabelControl CreateHeaderLabel(string text, int x, int y)
        {
            return new LabelControl
            {
                Text = text,
                Location = new Point(x, y),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(180, 18),
                Appearance = { Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), ForeColor = Color.FromArgb(40, 40, 40) }
            };
        }

        private static LabelControl CreateValueLabel(string text, int x, int y, bool isUserName)
        {
            var lbl = new LabelControl
            {
                Text = text,
                Location = new Point(x, y),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(185, 16)
            };

            if (isUserName)
            {
                lbl.Appearance.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
                lbl.Appearance.ForeColor = Color.FromArgb(0, 80, 160);
            }
            else
            {
                lbl.Appearance.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular);
                lbl.Appearance.ForeColor = Color.FromArgb(80, 80, 80);
            }

            return lbl;
        }
    }
}
