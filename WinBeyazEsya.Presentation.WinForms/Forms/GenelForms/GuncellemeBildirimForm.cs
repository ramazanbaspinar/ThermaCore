namespace WinBeyazEsya.Presentation.WinForms.Forms.GenelForms
{
    public partial class GuncellemeBildirimForm : DevExpress.XtraEditors.XtraForm
    {
        public GuncellemeBildirimForm(string eskiVersiyon, string yeniVersiyon, bool zorunluGuncelleme)
        {
            InitializeComponent();

            lblOldVersionValue.Text = $"v{eskiVersiyon}";
            lblNewVersionValue.Text = $"v{yeniVersiyon}";

            if (zorunluGuncelleme)
            {
                lblAciklama.Text = "Bu güncelleme zorunludur. Sisteme giriş yapabilmek için güncellemeniz gerekmektedir.";
                lblBaslik.Text = "Zorunlu Güncelleme!";
                pnlHeader.BackColor = System.Drawing.Color.FromArgb(180, 50, 50);
                btnDahaSonra.Visible = false;
                // Güncelle butonunu ortala
                btnSimdiGuncelle.Location = new System.Drawing.Point(140, 17);
            }
            else
            {
                lblAciklama.Text = "Sisteminiz için yeni bir sürüm yayınlandı. Şimdi güncellemek ister misiniz?";
                btnDahaSonra.Visible = true;
            }
        }

        private void btnSimdiGuncelle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDahaSonra_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
