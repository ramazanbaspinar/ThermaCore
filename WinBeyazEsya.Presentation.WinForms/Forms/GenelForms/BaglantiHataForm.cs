using WinBeyazEsya.Application.Interfaces.Configuration;
using WinBeyazEsya.Application.Interfaces.System;

namespace WinBeyazEsya.Presentation.WinForms.Forms.GenelForms
{
    public partial class BaglantiHataForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly IAppConfigService _configService;
        private readonly ITenantDatabaseSetupService _sistemVeritabaniService;

        public BaglantiHataForm(IAppConfigService configService, ITenantDatabaseSetupService sistemVeritabaniService)
        {
            _configService = configService;
            _sistemVeritabaniService = sistemVeritabaniService;
            InitializeComponent();
        }

        private void btnSihirbaziAc_Click(object sender, EventArgs e)
        {
            var wizard = new KurulumSihirbaziForm(_configService, _sistemVeritabaniService);
            this.Hide();
            wizard.ShowDialog();
            this.Close();
        }
    }
}
