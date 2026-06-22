using DevExpress.XtraEditors;
using System;
using System.Linq;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.DTOs.Security;
using ThermaCore.Application.Interfaces.Management;
using ThermaCore.Application.Interfaces.Security;
using ThermaCore.Application.Services.Management;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Forms.YetkilendirmeForms;
using ThermaCore.Presentation.WinForms.Helpers;


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

            BaseKartTuru = Domain.Enums.ModuleType.User;
            DataLayoutControl = myDataLayoutControl1;
            Bll = _userService;
        }


        protected override void EventsLoad()
        {
            base.EventsLoad();
            glufRol.SearchButtonClicked += GlufRol_SearchButtonClicked;
        }

        public override void Yukle()
        {
            // GridLookUpFind için datasource doldur
            var roller = _roleService.GetActiveRoles().ToList();
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
            ButonEnabledDurumu();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (UserDto)OldEntity;
            
            txtKullaniciAdi.Text = entity.Code;
            txtAd.Text = entity.FirstName;
            txtSoyad.Text = entity.LastName;
            txtEmail.Text = entity.Email;
            txtSifre.Text = Id > 0 ? "********" : ""; // Şifre kutusu güncelleme modunda ******** dolar
            glufRol.EditValue = entity.UserRoleId == 0 ? (long?)null : entity.UserRoleId;
            tglDurum.IsOn = entity.IsActive;
        }

        protected override void FocusControlByPropertyName(string propertyName)
        {
            base.FocusControlByPropertyName(propertyName);

            // Base'deki genel bulucu eşleşmezse özel durumlar:
            if (propertyName == nameof(UserDto.UserRoleId))
            {
                glufRol.Focus();
            }
            else if (propertyName == nameof(UserDto.IsActive))
            {
                tglDurum.Focus();
            }
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
                Password = txtSifre.Text == "********" ? "" : txtSifre.Text, // Eğer ******** ise veya boşsa arkada eski şifre korunacak (UserService)
                UserRoleId = glufRol.EditValue != null && glufRol.EditValue != DBNull.Value ? Convert.ToInt64(glufRol.EditValue) : 0,
                IsActive = tglDurum.IsOn
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
                            // Listeye yeni eklenmiş olabilecek kayıtlar için veri kaynağını tazele
                            glufRol.Properties.DataSource = _roleService.GetActiveRoles().ToList();
                            glufRol.EditValue = seciliRol.Id;
                        }
                    }
                }
            }
        }

        protected override bool EntityInsert()
        {
            var dto = (UserDto)CurrentEntity;
            dto.Id = BaseIslemTuru.IdOlustur(OldEntity);
            Id = _userService.Insert(dto);
            return true;
        }

        protected override bool EntityUpdate()
        {
            var dto = (UserDto)CurrentEntity;
            _userService.Update(dto);
            return true;
        }

        protected override void EntityDelete()
        {
            if (Id <= 0) return;
            if (Messages.SilMesaj("Kullanıcı") == DialogResult.Yes)
            {
                try
                {
                    _userService.Delete(Id);
                    RefreshYapilacak = true;
                    Close();
                }
                catch (Exception ex)
                {
                    Messages.HataMesaji(ex.Message);
                }
            }
        }
    }
}