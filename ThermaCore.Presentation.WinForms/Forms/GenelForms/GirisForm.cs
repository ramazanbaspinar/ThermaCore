using DevExpress.XtraEditors;
using System.Configuration;

namespace WinProjectUI.GenelForms
{
    public partial class GirisForm : XtraForm
    {
        public GirisForm()
        {
            InitializeComponent();
        }

        private void picPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtSifre.Properties.UseSystemPasswordChar = false;
        }

        private void picPassword_MouseUp(object sender, MouseEventArgs e)
        {
            txtSifre.Properties.UseSystemPasswordChar = true;

        }

        private void frmLogin_Activated(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text != "")
                txtSifre.Focus();
            else
                txtKullaniciAdi.Focus();
        }
        private void gluDil_EditValueChanged(object sender, EventArgs e)
        {

        }

        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[""].ConnectionString;
        }
    }
}
