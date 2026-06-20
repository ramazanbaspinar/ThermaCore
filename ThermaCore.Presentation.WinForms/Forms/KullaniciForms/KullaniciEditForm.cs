using DevExpress.XtraEditors;
using System;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.DTOs.Security;
using ThermaCore.Application.Interfaces.Management;
using ThermaCore.Application.Interfaces.Security;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Forms.YetkilendirmeForms;

namespace ThermaCore.Presentation.WinForms.Forms.KullaniciForms
{
    public partial class KullaniciEditForm : BaseEditForm
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public KullaniciEditForm(IUserService userService, IRoleService roleService)
        {
            InitializeComponent();
            _userService = userService;
            _roleService = roleService;

            DataLayoutControl = myDataLayoutControl1;
            Bll = _userService;
        }

        protected override void EventsLoad()
        {
            base.EventsLoad();
            txtKullaniciAdi.EditValueChanged += Control_EditValueChanged;
            txtAd.EditValueChanged += Control_EditValueChanged;
            txtSoyad.EditValueChanged += Control_EditValueChanged;
            txtEmail.EditValueChanged += Control_EditValueChanged;
            txtSifre.EditValueChanged += Control_EditValueChanged;
            glufRol.EditValueChanged += Control_EditValueChanged;

            glufRol.SearchButtonClicked += GlufRol_SearchButtonClicked;
        }

        public override void Yukle()
        {
            // GridLookUpFind için datasource doldur
            var roller = _roleService.GetActiveRoles();
            glufRol.Properties.DataSource = roller;
            glufRol.Properties.ValueMember = "Id";
            glufRol.Properties.DisplayMember = "RoleName";

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                OldEntity = new UserDto { IsActive = true };
                Id = -1;
            }
            else
            {
                OldEntity = _userService.GetById(Id);
            }

            NesneyiKontrollereBagla();
            
            // Yukle sonrası tüm form elemanları temiz kabul edilir (GeriAl düzgün çalışması için)
            txtKullaniciAdi.IsModified = false;
            txtAd.IsModified = false;
            txtSoyad.IsModified = false;
            txtEmail.IsModified = false;
            txtSifre.IsModified = false;
            glufRol.IsModified = false;
            
            ButonEnabledDurumu();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (UserDto)OldEntity;
            
            txtKullaniciAdi.Text = entity.Code;
            txtAd.Text = entity.FirstName;
            txtSoyad.Text = entity.LastName;
            txtEmail.Text = entity.Email;
            txtSifre.Text = ""; // Şifre kutusu her zaman boş gelir (hash gizliliği)
            glufRol.EditValue = entity.UserRoleId == 0 ? (long?)null : entity.UserRoleId;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new UserDto
            {
                Id = Id,
                Code = txtKullaniciAdi.Text,
                FirstName = txtAd.Text,
                LastName = txtSoyad.Text,
                Email = txtEmail.Text,
                Password = txtSifre.Text, // Eğer boşsa arkada eski şifre korunacak (UserService)
                UserRoleId = (long)(glufRol.EditValue ?? 0L),
                IsActive = true
            };
            
            ButonEnabledDurumu();
        }

        private void GlufRol_SearchButtonClicked(object? sender, EventArgs e)
        {
            using (var frm = new RolListForm())
            {
                frm.EklenebilecekEntityVar = true; // Seçim modu aktif
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.SelectedEntities != null && frm.SelectedEntities.Count > 0)
                    {
                        var seciliRol = frm.SelectedEntities[0] as RoleDto;
                        if (seciliRol != null)
                        {
                            glufRol.EditValue = seciliRol.Id;
                        }
                    }
                }
            }
        }
    }
}