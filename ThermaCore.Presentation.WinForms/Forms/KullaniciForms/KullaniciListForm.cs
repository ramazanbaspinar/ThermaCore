using System;
using System.Linq;
using System.Windows.Forms;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Management;
using ThermaCore.Application.Interfaces.Security;
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

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = _userService.GetAll().ToList();
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
    }
}