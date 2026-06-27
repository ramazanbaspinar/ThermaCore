using System;
using System.Linq;
using System.Windows.Forms;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Management;
using ThermaCore.Application.Interfaces.Security;
using ThermaCore.Application.Services.Management;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;

namespace ThermaCore.Presentation.WinForms.Forms.KullaniciForms
{
    public partial class KullaniciListForm : BaseListForm
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly ThermaCore.Application.Interfaces.System.ITenantDatabaseCrudService _tenantService;
        private readonly IBranchService _branchService;

        public KullaniciListForm(
            IUserService userService, 
            IRoleService roleService,
            ThermaCore.Application.Interfaces.System.ITenantDatabaseCrudService tenantService,
            IBranchService branchService)
        {
            InitializeComponent();
            _userService = userService;
            _roleService = roleService;
            _tenantService = tenantService;
            _branchService = branchService;

            Bll = _userService;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = ThermaCore.Domain.Enums.ModuleType.User;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;

            if (btnBagliKayitlar != null)
            {
                btnBagliKayitlar.Caption = "İstisnai Yetkiler";
            }
            ShowItems = new DevExpress.XtraBars.BarItem[] { btnBagliKayitlar };
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = _userService.GetAll().Where(x => x.IsActive == AktifKartlariGoster).ToList();
        }

        protected override void ShowEditForm(long id)
        {
            using (var form = new KullaniciEditForm(_userService, _roleService, _tenantService, _branchService))
            {
                form.IdAtaVeAc(id);
                
                // Eğer Modal ise kapatılınca listeyi yenile
                if (form.RefreshYapilacak && !EklenebilecekEntityVar) 
                    Listele();
            }
        }

        protected override void EntityDelete()
        {
            if (Tablo.FocusedRowHandle < 0) return;
            long id = 0;
            long.TryParse(Tablo.GetFocusedRowCellValue("Id")?.ToString(), out id);
            
            if (id > 0 && ThermaCore.Presentation.WinForms.Helpers.Messages.SilMesaj("Kullanıcı") == DialogResult.Yes)
            {
                _userService.Delete(id);
                Listele();
            }
        }

        protected override void BagliKayitAc()
        {
            if (Tablo.FocusedRowHandle < 0) return;
            long id = 0;
            long.TryParse(Tablo.GetFocusedRowCellValue("Id")?.ToString(), out id);
            
            if (id > 0)
            {
                var userCode = Tablo.GetFocusedRowCellValue("Code")?.ToString();
                if (!string.IsNullOrEmpty(userCode) && (userCode.ToLower() == "admin" || userCode.ToLower() == "thermacore"))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Sistem Yöneticisi (ADMIN/THERMACORE) tüm yetkilere sahiptir. Bu kullanıcılar için istisnai yetki tanımlaması yapılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var form = new ThermaCore.Presentation.WinForms.Forms.YetkilendirmeForms.KullaniciYetkiEditForm())
                {
                    form.IdAtaVeAc(id);
                }
            }
        }
    }
}