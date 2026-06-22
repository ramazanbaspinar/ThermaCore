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

        public KullaniciListForm(IUserService userService, IRoleService roleService)
        {
            InitializeComponent();
            _userService = userService;
            _roleService = roleService;

            Bll = _userService;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = ThermaCore.Domain.Enums.ModuleType.User;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = _userService.GetAll().Where(x => x.IsActive == AktifKartlariGoster).ToList();
        }

        protected override void ShowEditForm(long id)
        {
            using (var form = new KullaniciEditForm(_userService, _roleService))
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
    }
}